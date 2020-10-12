using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using System.Net.Http;

namespace QnAMaker.Tests
{
    public abstract class BaseTests
    {
        public static bool IsTestTenant = false;
        private static readonly string QnAMakerSubscriptionKey;

        static BaseTests()
        {
            // Retrieve the configuration information.
            QnAMakerSubscriptionKey = "a0d15e526041495e884f86cc0f3e24fd";
        }

        protected IQnAMakerClient GetQnAMakerClient(DelegatingHandler handler)
        {
            IQnAMakerClient client = new QnAMakerClient(new ApiKeyServiceClientCredentials(QnAMakerSubscriptionKey), handlers: handler)
            {
                Endpoint = "https://qnamakerteambugbash-northeurope-v2.cognitiveservices.azure.com"
            };

            return client;
        }
    }
}
