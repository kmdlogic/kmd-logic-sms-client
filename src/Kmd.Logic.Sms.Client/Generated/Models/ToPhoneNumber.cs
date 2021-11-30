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

    public partial class ToPhoneNumber
    {
        /// <summary>
        /// Initializes a new instance of the ToPhoneNumber class.
        /// </summary>
        public ToPhoneNumber()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ToPhoneNumber class.
        /// </summary>
        public ToPhoneNumber(string number = default(string))
        {
            Number = number;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Number != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(Number, "^\\+?[1-9]\\d{1,14}$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "Number", "^\\+?[1-9]\\d{1,14}$");
                }
            }
        }
    }
}
