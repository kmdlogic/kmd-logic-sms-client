// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kmd.Logic.Sms.Client.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    public partial class LogicProviderConfigProviderConfigurationResponse
    {
        /// <summary>
        /// Initializes a new instance of the
        /// LogicProviderConfigProviderConfigurationResponse class.
        /// </summary>
        public LogicProviderConfigProviderConfigurationResponse()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// LogicProviderConfigProviderConfigurationResponse class.
        /// </summary>
        /// <param name="displayName">A custom name that can be used to later
        /// understand the purpose of
        /// this provider configuration.</param>
        /// <param name="providerConfigurationId">The unique Id generated for
        /// each Provider Config</param>
        public LogicProviderConfigProviderConfigurationResponse(string displayName, System.Guid providerConfigurationId, LogicProviderConfig configuration)
        {
            DisplayName = displayName;
            ProviderConfigurationId = providerConfigurationId;
            Configuration = configuration;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets a custom name that can be used to later understand the
        /// purpose of
        /// this provider configuration.
        /// </summary>
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the unique Id generated for each Provider Config
        /// </summary>
        [JsonProperty(PropertyName = "providerConfigurationId")]
        public System.Guid ProviderConfigurationId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "configuration")]
        public LogicProviderConfig Configuration { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (DisplayName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DisplayName");
            }
            if (Configuration == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Configuration");
            }
            if (Configuration != null)
            {
                Configuration.Validate();
            }
        }
    }
}