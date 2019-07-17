using System;

namespace Kmd.Logic.Sms.Client.Sample
{
    public static class Program
    {
         private static string token = @"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6InpGTDB5ZGF2NDgxSHJDT2M0bk9MdTR2cDB2SDZxeTBvUS1SdlBzQW1vNlkifQ.eyJpc3MiOiJodHRwczovL2xvZ2ljaWRlbnRpdHlwcm9kLmIyY2xvZ2luLmNvbS9hYTBkNmYzYi04ZmIyLTQ3N2QtYWI4OC1iYjJlNjY0NjIwZTgvdjIuMC8iLCJleHAiOjE1NjMzNjkyMDgsIm5iZiI6MTU2MzM2NTYwOCwiYXVkIjoiZDM0MmY1MDctOWE0Ny00YzZhLTg1ZDktYTkyNTNjMzllNjYyIiwiZ2l2ZW5fbmFtZSI6IkRpbGVlcCBEYXlhbmFuZCIsImZhbWlseV9uYW1lIjoiUGFpIiwiZW1haWwiOiJxdnhAa21kLmRrIiwibXVuaWNpcGFsaXR5IjoiODk5IiwiYXV0aGVudGljYXRpb25Tb3VyY2UiOiJLTUQiLCJuYW1lIjoiRGlsZWVwIERheWFuYW5kIFBhaSIsInN1YiI6IjhkZWFmYzgzLTBjODEtNDY1Mi05ZGFhLWVjMmNkYWZhMDJkMyIsInJvbGVzIjpbXSwicGVybWlzc2lvbnMiOltdLCJub25jZSI6ImRlZmF1bHROb25jZSIsInNjcCI6InVzZXJfaW1wZXJzb25hdGlvbiIsImF6cCI6ImYwMWE3MmQ3LWEyN2UtNGMyZi1hMDFmLWE4NDBkMTBjODRhNCIsInZlciI6IjEuMCIsImlhdCI6MTU2MzM2NTYwOH0.LSn1eHWJiA9-fgL1FHP-hj8cccJtqSg7QO5coMAUfTYRLQdUXMuqGQN8rwPBTVi4qV2gzAN4XjxqpQFdH9kNGlK26qPEqihM9wnKMt368bbucYexWencGg9ptw5q39z7Ujrx3hAPq6LieXsrokdqgEwCZLPLmf3IHiBe6Cy35xNVpdRhHX4cNJ6FnOzWYx3aTd12oPGRk4UNWCX1l6qGKYDRbdH7rSibBeDO20tpOCW_ByKP5tDA_s0YYAwcNHRpohVPA-Nke2RimjbXtKGpzghiDwLju-0KVGAS_wUSonQgcnNiPig91rtPJvRGgLKEUb7DSQoJMi6OD1c3m7lqJQ";
        private static Guid subscriptionId = Guid.Parse("b8ed0d06-b7f1-42c3-a811-057849c2d6e4");
        private static string apiKey = "test";
        private static string sender = "KMDTest";
        private static string username = "ACce6f3145aee249a84f3b2edb971cedc0";
        private static string password = "b956223f604e2435b8d6ae23124f83f9";
        private static string accountSid = "ACce6f3145aee249a84f3b2edb971cedc0";
        private static string fromProperty = "+13479466088";
        private static string toPhoneNumber = "+919742122499";

        public static void Main(string[] args)
        {
                     
           CreateLogicConfiguration();
           CreateLogicConfiguration();
        }

        private static KMDLogicSMSServiceAPI getClientCrdentails()
        {
            var credentials = new TokenCredentials(token);
            var client = new KMDLogicSMSServiceAPI(credentials);
            return client;
        }
        private static void CreateTwilioConfiguration()
        {

            var client = getClientCrdentails();
            var resultTwilio = client.CreateTwilioProviderConfiguration(
               subscriptionId: subscriptionId,
               request: new ProviderConfigurationRequestTwilioProviderConfig(
                   displayName: "Twilio Provider-2",
                   new TwilioProviderConfig(
                       username: username,
                       password: password,
                       accountSid: accountSid,
                       fromProperty: fromProperty,
                       smsServiceWindow: null),
                   new SendTestSmsRequest(
                       toPhoneNumber: toPhoneNumber,
                       body: "Create Config from Sms Client")
                   ));
        }
          
            private static void CreateLogicConfiguration()
            {
                var client = getClientCrdentails();
                var resultLogic = client.CreateLogicProviderConfiguration(
            subscriptionId: subscriptionId,
                   request: new LogicProviderConfigurationRequestLogicProviderConfig(
                       displayName: "Logic Provider",
                       configuration: new LogicProviderConfig(
                           description: "Logic Provider",
                           smsServiceWindow: null)));
            }
        }
    }
}
