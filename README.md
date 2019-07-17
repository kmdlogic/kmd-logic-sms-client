# KMD Logic SMS Client
A dotnet client library for the KMD Logic SMS, which allows to create a provider configuration and send sms.

## How to use this client library
In projects or components where you need to send sms or integrate Logic sms service add a reference to nuget package [Kmd.Logic.Sms.Client](https://www.nuget.org/packages?q=Kmd.Logic.Sms.Client)

Use the `IKMDLogicSMSServiceAPI` like this 

```csharp
IKMDLogicSMSServiceAPI kMDLogicSMSServiceAPI;
kMDLogicSMSServiceAPI.CreateTwilioProviderConfigurationAsync(subscriptionId, TwilioConfigurationRequest);
    
kMDLogicSMSServiceAPI.SendSms(subscriptionId,smsRequest)

```

## How to contribute

TODO

## Contact us

Contact us at discover@kmdlogic.io for more information.


