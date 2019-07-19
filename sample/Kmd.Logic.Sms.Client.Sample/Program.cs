using System;
using System.Globalization;
using Kmd.Logic.Sms.Client.Models;
using Microsoft.Rest;

namespace Kmd.Logic.Sms.Client.Sample
{
    public static class Program
    {
        private static Guid subscriptionId = default; // subscription ID

        public static void Main()
        {
            int option = 0;
            while (option != 5)
            {
                Console.WriteLine("1. Create Twilio Provider Confguration");
                Console.WriteLine("2. Create LinkMobility Provider Confguration");
                Console.WriteLine("3. Create Logic Provider Confguration");
                Console.WriteLine("4. Send an SMS");
                Console.WriteLine("5. Exit");
                Console.Write("Select Option");
                var optionValue = Console.ReadLine();
                option = Convert.ToInt32(optionValue, CultureInfo.InvariantCulture);

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Twilio Provider Confguration Id :" + CreateTwilioConfiguration().ToString());
                        break;
                    case 2:
                        Console.WriteLine("LinkMobility Provider Confguration Id :" + CreateLinkMobilityProviderConfiguration().ToString());
                        break;
                    case 3:
                        Console.WriteLine("Logic Provider Confguration Id :" + CreateLogicConfiguration().ToString());
                        break;
                    case 4:
                        Console.WriteLine("Provide a  Provider Confguration Id");
                        Guid configId = Guid.Parse(Console.ReadLine());
                        Console.WriteLine("Sms Confguration ID :" + SendSms(configId).ToString());
                        break;
                    default:
                        break;
                }
            }
        }

        private static KMDLogicSMSServiceAPI GetClientCrdentails()
        {
            var credentials = new TokenCredentials(AppConfigurations.BearerToken);
            var client = new KMDLogicSMSServiceAPI(credentials);
            return client;
        }

        private static Guid CreateTwilioConfiguration()
        {
            var client = GetClientCrdentails();
            var resultTwilioProvider = client.CreateTwilioProviderConfiguration(
               subscriptionId: subscriptionId,
               request: new ProviderConfigurationRequestTwilioProviderConfig(
                   displayName: "Twilio Provider",
                   new TwilioProviderConfig(
                       username: AppConfigurations.TwilioUsername,
                       password: AppConfigurations.TwilioPassword,
                       accountSid: AppConfigurations.TwilioAccountSid,
                       fromProperty: AppConfigurations.TwilioFromProperty,
                       smsServiceWindow: null),
                   new SendTestSmsRequest(
                       toPhoneNumber: AppConfigurations.PhoneNumber,
                       body: "Create Config from Sms Client")));

            Guid providerConfigurationId = (resultTwilioProvider as ProviderConfigurationResponseTwilioProviderConfig).ProviderConfigurationId;

            return providerConfigurationId;
        }

        private static Guid CreateLinkMobilityProviderConfiguration()
        {
            var client = GetClientCrdentails();
            var resultLinkMobilityProvider = client.CreateLinkMobilityProviderConfiguration(
                subscriptionId: subscriptionId,
                request: new ProviderConfigurationRequestLinkMobilityProviderConfig(
                    displayName: "Link Mobility Provider",
                    new LinkMobilityProviderConfig(
                        apiKey: AppConfigurations.LinkMobilityApiKey,
                        sender: AppConfigurations.LinkMobilitySender),
                    new SendTestSmsRequest(
                        toPhoneNumber: AppConfigurations.PhoneNumber,
                        body: "Create Config from Sms Client")));

            Guid providerConfigurationId = (resultLinkMobilityProvider as ProviderConfigurationResponseLinkMobilityProviderConfig).ProviderConfigurationId;

            return providerConfigurationId;
        }

        private static Guid CreateLogicConfiguration()
        {
            var client = GetClientCrdentails();
            var resultLogicProvider = client.CreateLogicProviderConfiguration(
                subscriptionId: subscriptionId,
                request: new LogicProviderConfigurationRequestLogicProviderConfig(
                   displayName: "Logic Provider",
                   configuration: new LogicProviderConfig(
                       description: "Logic Provider Test",
                       smsServiceWindow: null)));

            Guid providerConfigurationId = (resultLogicProvider as ProviderConfigurationResponseLogicProviderConfig).ProviderConfigurationId;

            return providerConfigurationId;
        }

        private static Guid SendSms(Guid providerConfigurationId)
        {
            var client = GetClientCrdentails();
            var sendSmsResult = client.SendSms(
                subscriptionId: subscriptionId,
                request: new SendSmsRequest(
                    toPhoneNumber: "+919742122499",
                    body: "Use this given code for sample project",
                    callbackUrl: null,
                    providerConfigurationId: providerConfigurationId));

            Console.WriteLine($"Provider configuration ID :{providerConfigurationId}");
            return (sendSmsResult as SendSmsResponse).SmsMessageId;
        }
    }
}
