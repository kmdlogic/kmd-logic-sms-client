using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Kmd.Logic.Sms.Client.Sample
{
    public class ConfigurationValidator
    {
        private readonly AppConfiguration _configuration;

        public ConfigurationValidator(AppConfiguration configuration)
        {
            this._configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
        }

        internal bool Validate()
        {
            if (string.IsNullOrWhiteSpace(this._configuration.TokenProvider?.ClientId)
                || string.IsNullOrWhiteSpace(this._configuration.TokenProvider?.ClientSecret)
                || string.IsNullOrWhiteSpace(this._configuration.TokenProvider?.AuthorizationScope))
            {
                Log.Error(
                    "Invalid configuration. Please provide proper information to `appsettings.json`. Current data is: {@Settings}",
                    this._configuration);

                return false;
            }

            if (this._configuration.SmsOptions?.SubscriptionId == null)
            {
                Log.Error(
                    "Invalid configuration. Sms must have a configured SubscriptionId in `appsettings.json`. Current data is: {@Settings}",
                    this._configuration);

                return false;
            }

            if (this._configuration.ProviderConfigurationDetails?.ProviderConfigurationId == null)
            {
                Log.Error(
                    "Invalid configuration. Sms must have a configured ProviderConfigurationId in `appsettings.json`. Current data is: {@Settings}",
                    this._configuration);

                return false;
            }

            return true;
        }
    }
}
