using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
                    .AddInMemoryCollection(new[]
                    {
                        KeyValuePair.Create("<dummy>", "must exist to avoid issues"),
                    })
                    .AddCommandLine(args)
                    .Build()
                    .Get<CommandLineConfig>();

                switch (config.Action)
                {
                    case CommandLineAction.None:
                        Log.Information("You must provide arguments");
                        Log.Verbose("You must get a bearer token from the https://console.kmdlogic.io/ or using Client Credentials for your subscription.");
                        Log.Verbose("Examples:");
                        Log.Verbose("--Action=CreateTwilioConfig --SubscriptionId={SubscriptionId} --TwilioUserName={TwilioUserName} ... --BearerToken={BearerToken}", "INSERT", "INSERT", "INSERT");
                        Log.Verbose("--Action=CreateLinkMobilityCgiConfig --SubscriptionId={SubscriptionId} --LinkMobilityCgiUserName={LinkMobilityCgiUserName} ... --BearerToken={BearerToken}", "INSERT", "INSERT", "INSERT");
                        Log.Verbose("--Action=CreateLinkMobilityConfig --SubscriptionId={SubscriptionId} --LinkMobilityApiKey={LinkMobilityApiKey} ... --BearerToken={BearerToken}", "INSERT", "INSERT", "INSERT");
                        Log.Verbose("--Action=CreateLogicConfig --SubscriptionId={SubscriptionId} --LogicProviderSender={LogicProviderSender} ... --BearerToken={BearerToken}", "INSERT", "INSERT", "INSERT");
                        Log.Verbose("--Action=SendSms --ToPhoneNumber={ToPhone} --SubscriptionId={SubscriptionId} --ProviderConfigurationId={ProviderConfigurationId} ... --BearerToken={BearerToken}", "INSERT", "INSERT", "INSERT", "INSERT");
                        Log.Verbose("--Action=SendSmsBatch --ToPhoneNumber={ToPhone} --NumberOfMessages={NumberOfMessages} --CallbackUri={CallbackUri} --SubscriptionId={SubscriptionId} --ProviderConfigurationId={ProviderConfigurationId} ... --BearerToken={BearerToken}", "INSERT", "INSERT", "INSERT", "INSERT", "INSERT", "INSERT");
                        Log.Verbose("--Action=UpdateLogicProviderSender --LogicProviderSender={LogicProviderSender} --SubscriptionId={SubscriptionId} --ProviderConfigurationId={ProviderConfigurationId} --BearerToken={BearerToken}", "INSERT", "INSERT", "INSERT", "INSERT", "INSERT", "INSERT", "INSERT");
                        break;
                    case CommandLineAction.CreateTwilioConfig:
                        CreateTwilioConfiguration(config);
                        break;
                    case CommandLineAction.CreateLinkMobilityConfig:
                        CreateLinkMobilityProviderConfiguration(config);
                        break;
                    case CommandLineAction.CreateLogicConfig:
                        CreateLogicConfiguration(config);
                        break;
                    case CommandLineAction.CreateFakeConfig:
                        CreateFakeConfiguration(config);
                        break;
                    case CommandLineAction.CreateLinkMobilityCgiConfig:
                        CreateLinkMobilityCgiProviderConfiguration(config);
                        break;
                    case CommandLineAction.GetSms:
                        GetSms(config);
                        break;
                    case CommandLineAction.SendSms:
                        SendSms(config);
                        break;
                    case CommandLineAction.SendSmsBatch:
                        SendSmsBatch(config);
                        break;
                    case CommandLineAction.UpdateLogicProviderSender:
                        UpdateLogicProviderSender(config);
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

        private static ISmsClient GetApi(CommandLineConfig config)
        {
            if (string.IsNullOrEmpty(config.BearerToken))
            {
                throw new Exception("You must specify a bearer token with `--BearerToken={YourToken}`");
            }

            var credentials = new TokenCredentials(config.BearerToken);
            var client = new SmsClient(credentials);
            if (config.SmsApiBaseUri != null)
            {
                client.BaseUri = config.SmsApiBaseUri;
            }

            Log.Information("Created API with Base URI {BaseUri}", client.BaseUri);
            return client;
        }

        private static void GetSms(CommandLineConfig config)
        {
            var client = GetApi(config);

            if (config.SmsMessageId == Guid.Empty)
            {
                throw new Exception("You must specify an SMS ID with `--SmsMessageId=00000000-0000-0000-0000-000000000000`");
            }

            if (config.SubscriptionId == Guid.Empty)
            {
                throw new Exception("You must specify a subscription with `--SubscriptionId=00000000-0000-0000-0000-000000000000`");
            }

            var response = client.GetSms(config.SubscriptionId, config.SmsMessageId);
            Log.Information("Got SMS response: {@Sms}", response);
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

        private static Guid CreateLinkMobilityCgiProviderConfiguration(CommandLineConfig config)
        {
            var client = GetApi(config);
            var resultLinkMobilityCgiProviderConfig = client.CreateLinkMobilityCgiProviderConfiguration(
                subscriptionId: config.SubscriptionId,
                request: new LinkMobilityCgiProviderConfigProviderConfigurationRequest(
                    displayName: "SmsClientSampleLinkMobilityCgi",
                    new LinkMobilityCgiProviderConfig(
                        userName: config.LinkMobilityCgiUserName,
                        password: config.LinkMobilityCgiPassword,
                        platformId: config.LinkMobilityCgiPlatformId,
                        platformPartnerId: config.LinkMobilityCgiPlatformPartnerId,
                        source: config.LinkMobilityCgiSource,
                        smsServiceWindow: null),
                    new SendTestSmsRequest(
                        toPhoneNumber: config.ToPhoneNumber,
                        body: config.SmsBody)));

            Log.Information("Created provider config {@ProviderConfig}", resultLinkMobilityCgiProviderConfig);
            return (resultLinkMobilityCgiProviderConfig as LinkMobilityCgiProviderConfigProviderConfigurationResponse)?.ProviderConfigurationId ?? Guid.Empty;
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
                       sender: config.LogicProviderSender,
                       smsServiceWindow: null)));

            Log.Information("Created provider config {@ProviderConfig}", resultLogicProvider);
            return (resultLogicProvider as ProviderConfigurationResponseLogicProviderConfig)?.ProviderConfigurationId ?? Guid.Empty;
        }

        private static Guid CreateFakeConfiguration(CommandLineConfig config)
        {
            var client = GetApi(config);

            var createdConfiguration = client.CreateFakeSmsProviderConfiguration(
                subscriptionId: config.SubscriptionId,
                request: new FakeProviderConfigurationRequest(
                    displayName: "My Fake Config",
                    configuration: new FakeProviderConfig(
                        fromPhoneNumber: "+61411000000",
                        smsServiceWindow: null)));

            Log.Information("Created provider config {@ProviderConfig}", createdConfiguration);
            return (createdConfiguration as ProviderConfigurationResponseFakeProviderConfig)?.ProviderConfigurationId ?? Guid.Empty;
        }

        private static void SendSmsBatch(CommandLineConfig config)
        {
            var client = GetApi(config);
            var requestCorrelationId = $"|{Guid.NewGuid()}";
            var customHeaders = new Dictionary<string, List<string>>
            {
                { "Request-Id", new List<string> { requestCorrelationId } },
            };

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
                            providerConfigurationId: config.ProviderConfigurationId),
                        customHeaders: customHeaders))
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

        private static void UpdateLogicProviderSender(CommandLineConfig config)
        {
            var client = GetApi(config);

            var logicProviderConfig = client.GetLogicProviderConfiguration(
                providerConfigurationId: config.ProviderConfigurationId,
                subscriptionId: config.SubscriptionId);

            Log.Information(
                "Updating subscription {SubscriptionId} logic SMS provider {ProviderConfigId} from {OldSender} to {NewSender}",
                config.SubscriptionId,
                config.ProviderConfigurationId,
                logicProviderConfig.Configuration.Sender,
                config.LogicProviderSender);

            logicProviderConfig.Configuration.Sender = config.LogicProviderSender;

            var updateResult = client.UpdateLogicProviderConfiguration(
                subscriptionId: config.SubscriptionId,
                request: new LogicProviderConfigurationRequestLogicProviderConfig(
                    displayName: logicProviderConfig.DisplayName,
                    configuration: logicProviderConfig.Configuration),
                providerConfigurationId: logicProviderConfig.ProviderConfigurationId);

            Log.Information("Updating the Logic Provider responded result {@Result}", updateResult);
        }
    }
}
