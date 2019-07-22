# KMD Logic SMS Client
A dotnet client library for the KMD Logic SMS, which allows to create a provider configurations and send sms.

## How to use this client library
In projects or components integrate **Logic sms service** by adding a reference to nuget package [Kmd.Logic.Sms.Client](https://www.nuget.org/packages?q=Kmd.Logic.Sms.Client)

Use the `IKMDLogicSMSServiceAPI` like this 

```csharp
var credentials  = new TokenCredentials(token);
var client = new KMDLogicSMSServiceAPI(credentials)
```

Creating Provider Configuration using various providers

```csharp
\\Link Mobility
var result = client.CreateLinkMobilityProviderConfiguration(
                subscriptionId: subscriptionId,
                request: new ProviderConfigurationRequestLinkMobilityProviderConfig(
                    displayName: "Link Mobility Provider",
                    new LinkMobilityProviderConfig(
                        apiKey: apiKey,
                        sender: sender),
                    new SendTestSmsRequest(
                        toPhoneNumber: toPhoneNumber,
                        body:"Create Config from Sms Client")));
```
```csharp
\\Logic
var resultLogic = client.CreateLogicProviderConfiguration(
               subscriptionId: subscriptionId,
               request: new LogicProviderConfigurationRequestLogicProviderConfig(
                   displayName: "Logic Provider",
                   configuration: new LogicProviderConfig(
                       description: "Logic Provider",
                       smsServiceWindow: null)));
```

```csharp
\\Twilio
var resultTwilio = client.CreateTwilioProviderConfiguration(
               subscriptionId: subscriptionId,
               request: new ProviderConfigurationRequestTwilioProviderConfig(
                   displayName: "Twilio Provider",
                   new TwilioProviderConfig(
                       username: username,
                       password: password,
                       accountSid: accountSid,
                       fromProperty: fromProperty,
                       smsServiceWindow: null),
                   new SendTestSmsRequest(
                       toPhoneNumber: toPhoneNumber,
                       body: "Create Config from Sms Client")));
```

Send Sms using created provider configuration Id

```csharp
var sendSmsResult = client.SendSms(
                subscriptionId: subscriptionId,
                request: new SendSmsRequest(
                    toPhoneNumber: toPhoneNumber ,
                    body: "Sending Sample Sms",
                    callbackUrl: null,
                    providerConfigurationId: providerConfigurationId));
```

## Contact us

Contact us at discover@kmdlogic.io for more information.


