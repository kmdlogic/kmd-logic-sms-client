using System;
using System.Collections.Generic;
using System.Text;

namespace Kmd.Logic.Sms.Client.ServiceMessages
{
    public class SmsResponseDetails
    {
        /// <summary>
        /// Gets the Message Id for sms.
        /// </summary>
        public Guid SmsMessageId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceMessages.SmsResponseDetails"/> class.
        /// </summary>
        /// <param name="smsMessageId">SmsMessageId.</param>
        public SmsResponseDetails(Guid smsMessageId)
        {
            this.SmsMessageId = smsMessageId;
        }
    }
}
