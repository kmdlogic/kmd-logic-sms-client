# KMD Logic SMS Client

A dotnet client library for the KMD Logic SMS, which allows to create a provider configurations and send sms.

## How to use this client library

Add a reference to the [Kmd.Logic.Sms.Client](https://www.nuget.org/packages?q=Kmd.Logic.Sms.Client) nuget package.

Use the `IKMDLogicSMSServiceAPI` like this 

```C#
var credentials  = new TokenCredentials(token);
var client = new SmsClient(credentials)
```

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


