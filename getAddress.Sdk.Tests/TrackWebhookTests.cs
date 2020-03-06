using getAddress.Sdk.Api;
using getAddress.Sdk.Api.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;



namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class TrackWebhookTests
    {

        [TestMethod]
        public async Task GetWebhook()
        {
            var apiKey = KeyHelper.GetAdminKey();
            
            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            var service = new TrackWebhookService(apiKey, httpClient);

            var addResult = await service.Add("https://getaddress.io/track-test");

            Assert.IsTrue(addResult.IsSuccess);

            var getResult = await service.Get(addResult.SuccessfulResult.Id);

            Assert.IsTrue(getResult.IsSuccess);

            var listResult = await service.List();

            Assert.IsTrue(listResult.IsSuccess && listResult.SuccessfulResult.Webhooks.Any());

            var testResult = await service.Test();

            Assert.IsTrue(testResult.IsSuccess);

            var removeResult = await service.Remove(addResult.SuccessfulResult.Id);

            Assert.IsTrue(removeResult.IsSuccess);
            
        }


    }
}
