using System;
using System.Net.Http;
using System.Threading.Tasks;
using Kmd.Logic.Identity.Authorization;
using Kmd.Logic.Sms.Client.ServiceMessages;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Kmd.Logic.Sms.Client.Sample
{
    public static class Program
    {
        /// <summary>
        /// Main method to start the sample.
        /// </summary>
        /// <param name="args">Array of arguments.</param>
        /// <returns>Representing the asynchronous operation.</returns>
        public static async Task Main(string[] args)
        {
            InitLogger();

            try
            {
                var config = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false)
                    .AddEnvironmentVariables()
                    .AddCommandLine(args)
                    .Build()
                    .Get<AppConfiguration>();

                await Run(config).ConfigureAwait(false);
            }

#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
            {
                Log.Fatal(ex, "Caught a fatal unhandled exception");

                // throw;
            }
#pragma warning restore CA1031 // Do not catch general exception types

            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void InitLogger()
        {
            Log.Logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .WriteTo.Console()
               .CreateLogger();
        }

        private static async Task Run(AppConfiguration configuration)
        {
            var validator = new ConfigurationValidator(configuration);
            if (!validator.Validate())
            {
                return;
            }

            using var httpClient = new HttpClient();
            using var tokenProviderFactory = new LogicTokenProviderFactory(configuration.TokenProvider);
            var smsClient = new SmsClient(httpClient, tokenProviderFactory, configuration.SmsOptions);
            var providerConfigurationId = configuration.ProviderConfigurationDetails.ProviderConfigurationId;

            // Sending an Sms
            var sendSmsRequest = BuildSendSmsRequest(configuration);
            Log.Information("Sending an Sms...");
            var sendSmsResult = await smsClient.SendSms(sendSmsRequest).ConfigureAwait(false);
            if (sendSmsResult == null)
            {
                Log.Error("Couldn't send an Sms");
                return;
            }

            Console.WriteLine(
                "Sms was sent successfully. SmsMessageId ID: {0} ",
                sendSmsResult.SmsMessageId);
        }

        private static SmsRequestDetails BuildSendSmsRequest(AppConfiguration configuration)
        {
            return new SmsRequestDetails(
                id: Guid.Empty,
                toPhoneNumber: "",
                body: configuration.SmsBody,
                callbackUrl: "",
                providerConfigurationId: configuration.ProviderConfigurationDetails.ProviderConfigurationId,
                userData: "");
        }
    }
}
