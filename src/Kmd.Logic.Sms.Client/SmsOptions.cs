using System;
using System.Collections.Generic;
using System.Text;

namespace Kmd.Logic.Sms.Client
{
    public sealed class SmsOptions
    {
        /// <summary>
        /// Gets or sets the Logic sms service.
        /// </summary>
        /// <remarks>
        /// This option should not be overridden except for testing purposes.
        /// </remarks>
        public Uri SmsServiceUri { get; set; } = new Uri("https://sms.shareddev.kmdlogic.io/");

        /// <summary>
        /// Gets or sets the Logic Subscription.
        /// </summary>
        public Guid SubscriptionId { get; set; }
    }
}
