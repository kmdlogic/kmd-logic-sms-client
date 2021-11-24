using System;
using System.Collections.Generic;
using System.Text;

namespace Kmd.Logic.Sms.Client
{
    /// <summary>
    /// Provide the configuration options for using the Sms service.
    /// </summary>
    public sealed class SmsOptions
    {
        /// <summary>
        /// Gets or sets the Logic Sms service.
        /// </summary>
        /// <remarks>
        /// This option should not be overridden except for testing purposes.
        /// </remarks>
        public Uri SmsServiceUri { get; set; } = new Uri("https://gateway.kmdlogic.io/file-security/v1");

        /// <summary>
        /// Gets or sets the Logic Subscription.
        /// </summary>
        public Guid SubscriptionId { get; set; }
    }
}
