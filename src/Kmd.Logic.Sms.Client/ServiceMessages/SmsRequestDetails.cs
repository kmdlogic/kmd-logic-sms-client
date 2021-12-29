using System;

namespace Kmd.Logic.Sms.Client.ServiceMessages
{
        public class SmsRequestDetails
        {
            /// <summary>
            /// Gets the subscription id.
            /// </summary>
            public Guid Id { get; }

            /// <summary>
            /// Gets the phone number.
            /// </summary>
            public string ToPhoneNumber { get; }

            /// <summary>
            /// Gets the body of the sms to be sent.
            /// </summary>
            public string Body { get; }

            /// <summary>
            /// Gets the callback url for sms.
            /// </summary>
            public string CallbackUrl { get; }

            /// <summary>
            /// Gets the provider configuration id for sms.
            /// </summary>
            public Guid ProviderConfigurationId { get; }

            /// <summary>
            /// Gets the userdata for sms to be sent.
            /// </summary>
            public string UserData { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="ServiceMessages.SmsRequestDetails"/> class.
            /// </summary>
            /// <param name="id">Subscription id.</param>
            /// <param name="toPhoneNumber">Phone number to sent an sms.</param>
            /// <param name="body">Body of the sms to be sent.</param>
            /// <param name="callbackUrl">Callback url for sms.</param>
            /// <param name="providerConfigurationId">Provider configuration id for sms.</param>
            /// <param name="userData">Userdata for sms to be sent.</param>
            public SmsRequestDetails(Guid id, string toPhoneNumber, string body, string callbackUrl, Guid providerConfigurationId, string userData)
            {
                this.Id = id;
                this.ToPhoneNumber = toPhoneNumber;
                this.Body = body;
                this.CallbackUrl = callbackUrl;
                this.ProviderConfigurationId = providerConfigurationId;
                this.UserData = userData;
            }
        }
 }
