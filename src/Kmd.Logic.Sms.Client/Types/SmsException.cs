using System;
using System.Collections.Generic;
using System.Text;

namespace Kmd.Logic.Sms.Client.Types
{
    /// <summary>
    /// Exception class to handle sms related errors.
    /// </summary>
    [Serializable]
#pragma warning disable CA2229 // Implement serialization constructors
    public class SmsException : Exception
#pragma warning restore CA2229 // Implement serialization constructors
    {
        /// <summary>
        /// Gets InnerMessage.
        /// </summary>
        public string InnerMessage { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsException"/> class.
        /// </summary>
        public SmsException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public SmsException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerMessage">Inner exception message.</param>
        public SmsException(string message, string innerMessage)
            : base(message)
        {
            this.InnerMessage = innerMessage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception message.</param>
        public SmsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
