// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kmd.Logic.Sms.Client
{
    using Microsoft.Rest;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// </summary>
    internal partial interface IInternalClient : System.IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        JsonSerializerSettings SerializationSettings { get; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        JsonSerializerSettings DeserializationSettings { get; }

        /// <summary>
        /// Subscription credentials which uniquely identify client
        /// subscription.
        /// </summary>
        ServiceClientCredentials Credentials { get; }


        /// <param name='subscriptionId'>
        /// </param>
        /// <param name='request'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> CreateFakeSmsProviderConfigurationWithHttpMessagesAsync(System.Guid subscriptionId, FakeProviderConfigurationRequest request, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch Fake Provider Configurations Details for a specific
        /// ProviderConfigurationId.
        /// </summary>
        /// <param name='providerConfigurationId'>
        /// The Provider Configuration ID
        /// </param>
        /// <param name='subscriptionId'>
        /// The Subscription ID
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> GetFakeSmsProviderConfigurationWithHttpMessagesAsync(System.Guid providerConfigurationId, System.Guid subscriptionId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates a provider configuration which delivers SMS via Fake
        /// Provider.
        /// </summary>
        /// <param name='subscriptionId'>
        /// A valid SubscriptionId in which you are an owner/contributor
        /// </param>
        /// <param name='providerConfigurationId'>
        /// A valid ProviderConfigurationId of the config which needs to be
        /// updated
        /// </param>
        /// <param name='request'>
        /// The request body
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> UpdateFakeSmsProviderConfigurationWithHttpMessagesAsync(System.Guid subscriptionId, System.Guid providerConfigurationId, FakeProviderConfigurationRequest request, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a provider configuration which delivers SMS via LINK
        /// Mobility SMS REST API (Common a.k.a. CGI).
        /// Url: https://linkmobility.com/services/link-sms-gateway/
        /// </summary>
        /// <param name='subscriptionId'>
        /// A valid SubscriptionId in which you are an owner/contributor
        /// </param>
        /// <param name='request'>
        /// The request body
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> CreateLinkMobilityCgiProviderConfigurationWithHttpMessagesAsync(System.Guid subscriptionId, LinkMobilityCgiProviderConfigProviderConfigurationRequest request, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch Link Mobility Cgi provider configurations details for a
        /// specific ProviderConfigurationId.
        /// </summary>
        /// <param name='providerConfigurationId'>
        /// The Provider Configuration ID
        /// </param>
        /// <param name='subscriptionId'>
        /// The Subscription ID
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<LinkMobilityCgiProviderConfigProviderConfigurationResponse>> GetLinkMobilityCgiProviderConfigurationWithHttpMessagesAsync(System.Guid providerConfigurationId, System.Guid subscriptionId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates a provider configuration which delivers SMS via LINK
        /// Mobility SMS REST API (Common a.k.a. CGI).
        /// Url: https://linkmobility.com/services/link-sms-gateway/
        /// </summary>
        /// <param name='subscriptionId'>
        /// A valid SubscriptionId in which you are an owner/contributor
        /// </param>
        /// <param name='providerConfigurationId'>
        /// A valid ProviderConfigurationId of the config which needs to be
        /// updated
        /// </param>
        /// <param name='request'>
        /// The request body
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> UpdateLinkMobilityCgiProviderConfigurationWithHttpMessagesAsync(System.Guid subscriptionId, System.Guid providerConfigurationId, LinkMobilityCgiProviderConfigProviderConfigurationRequest request, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a provider configuration which delivers SMS via Link
        /// Mobility.
        /// </summary>
        /// <param name='subscriptionId'>
        /// A valid SubscriptionId in which you are an owner/contributor
        /// </param>
        /// <param name='request'>
        /// The request body
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> CreateLinkMobilityProviderConfigurationWithHttpMessagesAsync(System.Guid subscriptionId, LinkMobilityProviderConfigProviderConfigurationRequest request, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch Link Mobility Provider Configurations Details for a specific
        /// ProviderConfigurationId.
        /// </summary>
        /// <param name='providerConfigurationId'>
        /// The Provider Configuration ID
        /// </param>
        /// <param name='subscriptionId'>
        /// The Subscription ID
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<LinkMobilityProviderConfigProviderConfigurationResponse>> GetLinkMobilityProviderConfigurationWithHttpMessagesAsync(System.Guid providerConfigurationId, System.Guid subscriptionId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates a provider configuration which delivers SMS via Link
        /// Mobility.
        /// </summary>
        /// <param name='subscriptionId'>
        /// A valid SubscriptionId in which you are an owner/contributor
        /// </param>
        /// <param name='providerConfigurationId'>
        /// A valid ProviderConfigurationId of the config which needs to be
        /// updated
        /// </param>
        /// <param name='request'>
        /// The request body
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> UpdateLinkMobilityProviderConfigurationWithHttpMessagesAsync(System.Guid subscriptionId, System.Guid providerConfigurationId, LinkMobilityProviderConfigProviderConfigurationRequest request, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a Provider configuration which delivers SMS via Logic.
        /// </summary>
        /// <param name='subscriptionId'>
        /// A valid SubscriptionId in which you are an owner/contributor
        /// </param>
        /// <param name='request'>
        /// The request body
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> CreateLogicProviderConfigurationWithHttpMessagesAsync(System.Guid subscriptionId, LogicProviderConfigLogicProviderConfigurationRequest request, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch Logic Provider Configurations for a specific
        /// ProviderConfigurationId.
        /// </summary>
        /// <param name='providerConfigurationId'>
        /// The Provider Configuration ID
        /// </param>
        /// <param name='subscriptionId'>
        /// The Subscription ID
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<LogicProviderConfigProviderConfigurationResponse>> GetLogicProviderConfigurationWithHttpMessagesAsync(System.Guid providerConfigurationId, System.Guid subscriptionId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates a provider configuration which delivers SMS via Logic.
        /// </summary>
        /// <param name='subscriptionId'>
        /// A valid SubscriptionId in which you are an owner/contributor
        /// </param>
        /// <param name='providerConfigurationId'>
        /// A valid ProviderConfigurationId of the config which needs to be
        /// updated
        /// </param>
        /// <param name='request'>
        /// The request body
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> UpdateLogicProviderConfigurationWithHttpMessagesAsync(System.Guid subscriptionId, System.Guid providerConfigurationId, LogicProviderConfigLogicProviderConfigurationRequest request, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all available provider configurations for the subscription.
        /// </summary>
        /// <param name='subscriptionId'>
        /// The subscription ID
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<IList<ProviderConfigurationListItem>>> GetAllProviderConfigurationsWithHttpMessagesAsync(System.Guid subscriptionId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Delete Provider Configurations for a specific
        /// ProviderConfigurationId.
        /// </summary>
        /// <param name='subscriptionId'>
        /// The Subscription ID
        /// </param>
        /// <param name='providerConfigurationId'>
        /// The Provider Configuration ID
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse> DeleteProviderConfigurationWithHttpMessagesAsync(System.Guid subscriptionId, System.Guid providerConfigurationId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieve message delivery details by message Id
        /// </summary>
        /// <param name='subscriptionId'>
        /// Consumer subscription Id
        /// </param>
        /// <param name='smsMessageId'>
        /// A unique identifier for the SMS message
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<GetSmsResponse>> GetSmsWithHttpMessagesAsync(System.Guid subscriptionId, System.Guid smsMessageId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Sends a single SMS message.
        /// </summary>
        /// <param name='subscriptionId'>
        /// Consumer subscription Id
        /// </param>
        /// <param name='request'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> SendSmsWithHttpMessagesAsync(System.Guid subscriptionId, SendSmsRequest request, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a provider configuration which delivers SMS via Twilio.
        /// </summary>
        /// <param name='subscriptionId'>
        /// A valid SubscriptionId in which you are an owner/contributor
        /// </param>
        /// <param name='request'>
        /// The request body
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> CreateTwilioProviderConfigurationWithHttpMessagesAsync(System.Guid subscriptionId, TwilioProviderConfigProviderConfigurationRequest request, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch Twilio Provider Configurations for a specific
        /// ProviderConfigurationId.
        /// </summary>
        /// <param name='providerConfigurationId'>
        /// The Provider Configuration ID
        /// </param>
        /// <param name='subscriptionId'>
        /// The Subscription ID
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<TwilioProviderConfigProviderConfigurationResponse>> GetTwilioProviderConfigurationWithHttpMessagesAsync(System.Guid providerConfigurationId, System.Guid subscriptionId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates a provider configuration which delivers SMS via Twilio.
        /// </summary>
        /// <param name='subscriptionId'>
        /// A valid SubscriptionId in which you are an owner/contributor
        /// </param>
        /// <param name='providerConfigurationId'>
        /// A valid ProviderConfigurationId of the config which needs to be
        /// updated
        /// </param>
        /// <param name='request'>
        /// The request body
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> UpdateTwilioProviderConfigurationWithHttpMessagesAsync(System.Guid subscriptionId, System.Guid providerConfigurationId, TwilioProviderConfigProviderConfigurationRequest request, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

    }
}
