using System;
using System.Collections.Generic;
using Kmd.Logic.Sms.Client.Models;

namespace Kmd.Logic.Sms.Client.Sample
{
    public class CommandLineConfig
    {
        public CommandLineAction Action { get; set; }

        public Guid SubscriptionId { get; set; }

        public Guid ProviderConfigurationId { get; set; }

        public Guid SmsMessageId { get; set; }

        public string BearerToken { get; set; }

        public string LinkMobilityApiKey { get; set; }

        public string LinkMobilitySender { get; set; } = "SMSSample";

        public string TwilioUsername { get; set; }

        public string TwilioAccountSid { get; set; }

        public string TwilioFromProperty { get; set; }

        public string TwilioPassword { get; set; }

        public string ToPhoneNumber { get; set; }

        public Uri SmsApiBaseUri { get; set; }

        public Uri CallbackUri { get; set; } = null;

        public string SmsBody { get; set; } = "From the SMS Client Sample";

        public int NumberOfMessages { get; set; } = 1;

        public int NumberOfThreads { get; set; } = 1;

        public string LogicProviderSender { get; set; } = "SMSSample";

        public string LinkMobilityCgiUserName { get; set; }

        public string LinkMobilityCgiPassword { get; set; }

        public string LinkMobilityCgiPlatformId { get; set; }

        public string LinkMobilityCgiPlatformPartnerId { get; set; }

        public string LinkMobilityCgiSource { get; set; } = "SMSSample";

        public string UserData { get; set; } = "CustomerId=123";

        // ToPhoneNumbers for sending bulk sms
        public static List<ToPhoneNumber> ToPhoneNumbers()
        {
            return new List<ToPhoneNumber>
            {
                new ToPhoneNumber { Number = "Phone number 1" },
                new ToPhoneNumber { Number = "Phone number 2" },
            };
        }
    }
}
