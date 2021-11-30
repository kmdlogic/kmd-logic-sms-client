# KMD Logic SMS Client

A dotnet client library for the KMD Logic SMS, which allows to create a provider configurations and send sms.

## Getting started in ASP.NET Core

To use this library in ASP.NET Core application add reference to [Kmd.Logic.Sms.Client](https://www.nuget.org/packages/Kmd.Logic.Sms.Client) nuget package, and add a reference to [Kmd.Logic.Identity.Authorization](https://www.nuget.org/packages/Kmd.Logic.Identity.Authorization).

Next register the services as follows:

```C#
services.AddHttpClient(); // https://www.nuget.org/packages/Microsoft.Extensions.Http
services.AddSingleton(new LogicTokenProviderFactory(
    new LogicTokenProviderOptions
    {
        ClientId = "Logic client credentials -> client ID",
        ClientSecret = "Logic client credentials -> client secret",
        AuthorizationScope = "Logic client credentials -> authorization scope",
    }));
services.AddScoped<SmsClient>(c =>
{
    var httpClientFactory = c.GetService<IHttpClientFactory>();
    var logicTokenProviderFactory = c.GetRequiredService<LogicTokenProviderFactory>();
    var client = new SmsClient(new TokenCredentials(logicTokenProviderFactory.GetProvider(httpClientFactory.CreateClient())));
    return client;
});
```

After that in order to use it just inject `ISmsClient` into constructor and use it like this:

```C#
var subscriptionId = new Guid("your Logic subscription ID");
var providerConfigurationId = new Guid("your Logic SMS configuration ID");
await _smsClient.SendSmsAsync(subscriptionId, new Kmd.Logic.Sms.Client.Models.SendSmsRequest
{
    Body = "Hello, world!",
    ProviderConfigurationId = providerConfigurationId,
    ToPhoneNumber = "put some phone number here",
});
```

## Getting started without a dependency injection container

Add a reference to the [Kmd.Logic.Sms.Client](https://www.nuget.org/packages?q=Kmd.Logic.Sms.Client) nuget package.

Create an instance of `ISmsClient` like this:

```C#
var credentials  = new TokenCredentials(token);
ISmsClient client = new SmsClient(credentials)
```

## Getting credentials for Logic SMS

Before you can use Logic SMS, you will need to create a Logic Subscription and obtain your `SubscriptionId` from https://console.kmdlogic.io/subscriptions.

You will need a [bearer token](https://jwt.io/introduction/) issued from [Logic Identity](https://kmdlogic.io/en/products/identity/) and it must have access to your logic subscription.

Typically, in SMS, you will want to use the [client credentials grant](https://auth0.com/docs/flows/concepts/client-credentials), and you'll have to request creation of client credentials via the console at `https://console.kmdlogic.io/subscriptions/{SubscriptionId}/client-credentials`.

However, there's a few other options we sometimes use for development or testing purposes.

1. Ensure you are a member of the subscription, and then acquire a token manually from [here](https://logicidentityprod.b2clogin.com/logicidentityprod.onmicrosoft.com/oauth2/v2.0/authorize?p=B2C_1A_signup_signin&client_id=f01a72d7-a27e-4c2f-a01f-a840d10c84a4&nonce=defaultNonce&redirect_uri=https%3A%2F%2Fjwt.ms&scope=openid%20https%3A%2F%2Flogicidentityprod.onmicrosoft.com%2FLogicAPI%2Fuser_impersonation&response_type=token&prompt=login)
2. Ensure you are member fo the subscription, and copy your personal token by spying on API requests made by the [logic console](https://console.kmdlogic.io).

## Creating Provider Configuration using various providers

### Fake

```C#
var fakeConfig = client.CreateFakeSmsProviderConfiguration(
    subscriptionId: config.SubscriptionId,
    request: new FakeProviderConfigurationRequest(
        displayName: "My Fake Config",
        configuration: new FakeProviderConfig(
            fromPhoneNumber: "+61411000000",
            smsServiceWindow: null)));
```

### Link Mobility (DK API)

```C#
var linkMobilityConfig = client.CreateLinkMobilityProviderConfiguration(
    subscriptionId: subscriptionId,
    request: new ProviderConfigurationRequestLinkMobilityProviderConfig(
        displayName: "My Link Mobility Provider",
        new LinkMobilityProviderConfig(
            apiKey: apiKey,
            sender: sender),
        new SendTestSmsRequest(
            toPhoneNumber: toPhoneNumber,
            body: "A test to validate the provider config")));
```

### Link Mobility CGI

```C#
var linkMobilityCgiConfig = client.CreateLinkMobilityCgiProviderConfiguration(
    subscriptionId: SubscriptionId,
    request: new LinkMobilityCgiProviderConfigProviderConfigurationRequest(
        displayName: "My Link Mobility Cgi Provider",
        new LinkMobilityCgiProviderConfig(
            userName: userName,
            password: password,
            platformId: platformId,
            platformPartnerId: platformPartnerId,
            source: source,
            smsServiceWindow: null),
        new SendTestSmsRequest(
            toPhoneNumber: toPhoneNumber,
            body: "A test to validate the provider config")));
```

### Logic

```c#
var logicConfig = client.CreateLogicProviderConfiguration(
   subscriptionId: subscriptionId,
   request: new LogicProviderConfigurationRequestLogicProviderConfig(
       displayName: "My Logic Provider",
       configuration: new LogicProviderConfig(
           description: "Logic Provider",
           smsServiceWindow: null)));
```

### Twilio

```C#
var twilioConfig = client.CreateTwilioProviderConfiguration(
   subscriptionId: subscriptionId,
   request: new ProviderConfigurationRequestTwilioProviderConfig(
       displayName: "My Twilio Provider",
       new TwilioProviderConfig(
           username: username,
           password: password,
           accountSid: accountSid,
           fromProperty: fromProperty,
           smsServiceWindow: null),
       new SendTestSmsRequest(
           toPhoneNumber: toPhoneNumber,
           body: "A test to validate the provider config")));
```
## Send SMS

### Send single SMS

```C#
var sendSmsResult = await _smsClient.SendSmsAsync(subscriptionId, new Kmd.Logic.Sms.Client.Models.SendSmsRequest
{
    Body = "Hello, world!",
    ProviderConfigurationId = providerConfigurationId,
    ToPhoneNumber = "put some phone number here",
    callbackUrl = "provide your callback Url",
    userData = "Can be anything upto 500 characters. If provided, this custom data will be passed to the callback"
});
```

### Send Bulk SMS

```C#
var sendBulkSmsResult = await _smsClient.SendBulkSmsAsync(subscriptionId, new Kmd.Logic.Sms.Client.Models.SendBulkSmsRequest
{
    ToPhoneNumber = [
        {
            number = "phone number 1"
        },
        {
            number = "phone number 2"
        }
    ],
    Body = "Hello, world!",
    ProviderConfigurationId = providerConfigurationId,
    callbackUrl = "provide your callback Url",
    userData = "string"
});
```

## Contact us

Contact us at discover@kmdlogic.io for more information.
