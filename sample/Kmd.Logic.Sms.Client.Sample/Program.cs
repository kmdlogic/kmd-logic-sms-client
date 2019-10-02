using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Kmd.Logic.Sms.Client.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Rest;
using Serilog;

namespace Kmd.Logic.Sms.Client.Sample
{
    public static class Program
    {
        [SuppressMessage("ReSharper", "CA1031", Justification = "We are logging the exception.")]
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                var config = new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .Build()
                    .Get<CommandLineConfig>();

                switch (config.Action)
                {
                    case CommandLineAction.CreateTwilioConfig:
                        CreateTwilioConfiguration(config);
                        break;
                    case CommandLineAction.CreateLinkMobilityConfig:
                        CreateLinkMobilityProviderConfiguration(config);
                        break;
                    case CommandLineAction.CreateLogicConfig:
                        CreateLogicConfiguration(config);
                        break;
                    case CommandLineAction.SendSms:
                        SendSms(config);
                        break;
                    case CommandLineAction.SendSmsBatch:
                        SendSmsBatch(config);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Unknown action {config.Action}");
                }

                return 0;
            }
            catch (Exception fatalException)
            {
                Log.Fatal(fatalException, "Fatal exception");
                return 1;
            }
            finally
            {
                Log.Information("Shutting down");
                Log.CloseAndFlush();
            }
        }

        private static KMDLogicSMSServiceAPI GetApi(CommandLineConfig config)
        {
            var credentials = new TokenCredentials(config.BearerToken);
            var client = new KMDLogicSMSServiceAPI(credentials);
            if (config.SmsApiBaseUri != null)
            {
                client.BaseUri = config.SmsApiBaseUri;
            }

            Log.Information("Created API with Base URI {BaseUri}", client.BaseUri);
            return client;
        }

        private static Guid CreateTwilioConfiguration(CommandLineConfig config)
        {
            var client = GetApi(config);

            var resultTwilioProvider = client.CreateTwilioProviderConfiguration(
                subscriptionId: config.SubscriptionId,
                request: new ProviderConfigurationRequestTwilioProviderConfig(
                    displayName: "SmsClientSampleTwilio",
                    new TwilioProviderConfig(
                        username: config.TwilioUsername,
                        password: config.TwilioPassword,
                        accountSid: config.TwilioAccountSid,
                        fromProperty: config.TwilioFromProperty,
                        smsServiceWindow: null),
                    new SendTestSmsRequest(
                        toPhoneNumber: config.ToPhoneNumber,
                        body: config.SmsBody)));

            Log.Information("Created provider config {@ProviderConfig}", resultTwilioProvider);
            return (resultTwilioProvider as ProviderConfigurationResponseTwilioProviderConfig)?.ProviderConfigurationId ?? Guid.Empty;
        }

        private static Guid CreateFakeConfiguration(CommandLineConfig config)
        {
            var client = GetApi(config);

            var resultTwilioProvider = client.CreateFa(
                subscriptionId: config.SubscriptionId,
                request: new ProviderConfigurationRequestTwilioProviderConfig(
                    displayName: "SmsClientSampleTwilio",
                    new TwilioProviderConfig(
                        username: config.TwilioUsername,
                        password: config.TwilioPassword,
                        accountSid: config.TwilioAccountSid,
                        fromProperty: config.TwilioFromProperty,
                        smsServiceWindow: null),
                    new SendTestSmsRequest(
                        toPhoneNumber: config.ToPhoneNumber,
                        body: config.SmsBody)));

            Log.Information("Created provider config {@ProviderConfig}", resultTwilioProvider);
            return (resultTwilioProvider as ProviderConfigurationResponseTwilioProviderConfig)?.ProviderConfigurationId ?? Guid.Empty;
        }

        private static Guid CreateLinkMobilityProviderConfiguration(CommandLineConfig config)
        {
            var client = GetApi(config);
            var resultLinkMobilityProvider = client.CreateLinkMobilityProviderConfiguration(
                subscriptionId: config.SubscriptionId,
                request: new ProviderConfigurationRequestLinkMobilityProviderConfig(
                    displayName: "SmsClientSampleLinkMobility",
                    new LinkMobilityProviderConfig(
                        apiKey: config.LinkMobilityApiKey,
                        sender: config.LinkMobilitySender),
                    new SendTestSmsRequest(
                        toPhoneNumber: config.ToPhoneNumber,
                        body: config.SmsBody)));

            Log.Information("Created provider config {@ProviderConfig}", resultLinkMobilityProvider);
            return (resultLinkMobilityProvider as ProviderConfigurationResponseLinkMobilityProviderConfig)?.ProviderConfigurationId ?? Guid.Empty;
        }

        private static Guid CreateLogicConfiguration(CommandLineConfig config)
        {
            var client = GetApi(config);
            var resultLogicProvider = client.CreateLogicProviderConfiguration(
                subscriptionId: config.SubscriptionId,
                request: new LogicProviderConfigurationRequestLogicProviderConfig(
                   displayName: "SmsClientSampleLogicProvider",
                   configuration: new LogicProviderConfig(
                       description: "Logic Provider Test",
                       smsServiceWindow: null)));

            Log.Information("Created provider config {@ProviderConfig}", resultLogicProvider);
            return (resultLogicProvider as ProviderConfigurationResponseLogicProviderConfig)?.ProviderConfigurationId ?? Guid.Empty;
        }

        private static void SendSmsBatch(CommandLineConfig config)
        {
            var client = GetApi(config);
            var requestCorrelationId = $"|{Guid.NewGuid()}";
            client.HttpClient.DefaultRequestHeaders.Add("Request-Id", new[] { requestCorrelationId });

            var results = Enumerable
                .Range(1, config.NumberOfMessages)
                .AsParallel()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .WithDegreeOfParallelism(config.NumberOfThreads)
                .Select(i => client.SendSmsWithHttpMessagesAsync(
                        subscriptionId: config.SubscriptionId,
                        request: new SendSmsRequest(
                            toPhoneNumber: config.ToPhoneNumber,
                            body: config.SmsBody,
                            callbackUrl: $"{config.CallbackUri}",
                            providerConfigurationId: config.ProviderConfigurationId)))
                .Select(task => task.GetAwaiter().GetResult())
                .ToArray();

            var summary = new
            {
                RequestCorrelationId = requestCorrelationId,
                NumberOfMessages = results.Count(),
                StatusCodeCounts = results
                    .GroupBy(r => r.Response.StatusCode)
                    .Select(g => new
                    {
                        HttpStatusCode = g.Key,
                        TotalCount = g.Count(),
                        First3 = g.Take(3).Select(ResponseAsLogable).ToArray(),
                    })
                    .ToArray(),
            };

            Log.Information("Sent SMS with results {@Results}", summary);
        }

        private static object ResponseAsLogable(HttpOperationResponse<object> response)
        {
            return new
            {
                Response = response.Response.Headers,
                response.Body,
            };
        }

        private static Guid SendSms(CommandLineConfig config)
        {
            var client = GetApi(config);

            var sendSmsResult = client.SendSms(
                subscriptionId: config.SubscriptionId,
                request: new SendSmsRequest(
                    toPhoneNumber: config.ToPhoneNumber,
                    body: config.SmsBody,
                    callbackUrl: $"{config.CallbackUri}",
                    providerConfigurationId: config.ProviderConfigurationId));

            Log.Information("Sent SMS and got result {@Result}", sendSmsResult);
            return (sendSmsResult as SendSmsResponse)?.SmsMessageId ?? Guid.Empty;
        }
    }
}
