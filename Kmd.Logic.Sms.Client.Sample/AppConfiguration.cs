using Kmd.Logic.Identity.Authorization;
using System;

namespace Kmd.Logic.Sms.Client.Sample
{
    public class AppConfiguration
    {
        /// <summary>
        /// Gets or sets authorization token.
        /// </summary>
        public LogicTokenProviderOptions TokenProvider { get; set; } = new LogicTokenProviderOptions();

        /// <summary>
        /// Gets or sets Sms configuration options.
        /// </summary>
        public SmsOptions SmsOptions { get; set; } = new SmsOptions();

        /// <summary>
        /// Gets or sets Provider Configuration details.
        /// </summary>
        public ProviderConfigurationDetails ProviderConfigurationDetails { get; set; } = new ProviderConfigurationDetails();


        /// <summary>
        /// Gets or sets Sms Body details.
        /// </summary>
        public string SmsBody { get; set; } = "From the SMS Client Sample";
    }
}
