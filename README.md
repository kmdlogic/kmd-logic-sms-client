# KMD Logic SMS Client
A dotnet client library for the KMD Logic SMS, which allows to create a provider configurations and send sms.

## How to use this client library
In projects or components integrate **Logic sms service** by adding a reference to nuget package [Kmd.Logic.Sms.Client](https://www.nuget.org/packages?q=Kmd.Logic.Sms.Client)

Use the `IKMDLogicSMSServiceAPI` like this 

```csharp
IKMDLogicSMSServiceAPI kMDLogicSMSServiceAPI;

//Create a Sms Provider configuration
kMDLogicSMSServiceAPI.CreateTwilioProviderConfigurationAsync(subscriptionId, TwilioConfigurationRequest);
    
//Send an Sms 
kMDLogicSMSServiceAPI.SendSms(subscriptionId,smsRequest)

```

## How to contribute

TODO

## Contact us

Contact us at discover@kmdlogic.io for more information.


