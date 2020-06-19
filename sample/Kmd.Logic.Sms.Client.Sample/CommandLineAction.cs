namespace Kmd.Logic.Sms.Client.Sample
{
    public enum CommandLineAction
    {
        None = 0,
        CreateTwilioConfig,
        CreateLinkMobilityCgiConfig,
        CreateLinkMobilityConfig,
        CreateLogicConfig,
        CreateFakeConfig,
        GetSms,
        SendSms,
        SendSmsBatch,
        UpdateLogicProviderSender,
    }
}