# KMD Logic SMS Client

A dotnet client library for the KMD Logic SMS, which allows to create a provider configurations and send sms.

## How to use this client library

Add a reference to the [Kmd.Logic.Sms.Client](https://www.nuget.org/packages?q=Kmd.Logic.Sms.Client) nuget package.

Create an instance of `ISmsClient` like this:

```C#
var credentials  = new TokenCredentials(token);
var client = new SmsClient(credentials)
```

> NOTE: you will need a `SubscriptionId` from https://console.kmdlogic.io/subscriptions

> NOTE: you will need a bearer token with access to your logic subscription. You can get one from:
> 1. Client credentials from `https://console.kmdlogic.io/subscriptions/{SubscriptionId}/client-credentials`
> 2. Acquire one manually from [here](https://logicidentityprod.b2clogin.com/logicidentityprod.onmicrosoft.com/oauth2/v2.0/authorize?p=B2C_1A_signup_signin&client_id=f01a72d7-a27e-4c2f-a01f-a840d10c84a4&nonce=defaultNonce&redirect_uri=https%3A%2F%2Fjwt.ms&scope=openid%20https%3A%2F%2Flogicidentityprod.onmicrosoft.com%2FLogicAPI%2Fuser_impersonation&response_type=token&prompt=login)
> 3. Copy your personal token by spying on API requests made by the [logic console](https://console.kmdlogic.io)

Creating Provider Configuration using various providers

```C#
// Fake
var fakeConfig = client.CreateFakeSmsProviderConfiguration(
    subscriptionId: config.SubscriptionId,
    request: new FakeProviderConfigurationRequest(
        displayName: "My Fake Config",
        configuration: new FakeProviderConfig(
            fromPhoneNumber: "+61411000000",
            smsServiceWindow: null)));
```

```C#
// Link Mobility
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

```c#
// Logic
var logicConfig = client.CreateLogicProviderConfiguration(
   subscriptionId: subscriptionId,
   request: new LogicProviderConfigurationRequestLogicProviderConfig(
       displayName: "My Logic Provider",
       configuration: new LogicProviderConfig(
           description: "Logic Provider",
           smsServiceWindow: null)));
```

```C#
// Twilio
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

Send an SMS using created provider configuration Id

```C#
var sendSmsResult = client.SendSms(
    subscriptionId: subscriptionId,
    request: new SendSmsRequest(
        toPhoneNumber: toPhoneNumber ,
        body: "An SMS sent using the client",
        callbackUrl: null,
        providerConfigurationId: providerConfigurationId));
```

## Contact us

Contact us at discover@kmdlogic.io for more information.


