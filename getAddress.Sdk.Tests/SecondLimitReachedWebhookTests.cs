using getAddress.Sdk.Api.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class SecondLimitReachedWebhookTests
    {

        [TestMethod]
        public async Task GetSecondReachedWebhook()
        {
            var apiKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new AdminKey(apiKey), httpClient))
            {
                var list = await api.SecondLimitReachedWebhook.List();

                Assert.IsTrue(list.IsSuccess);

                if (list.SuccessfulResult.Webhooks.Any())
                {
                    var result = await api.SecondLimitReachedWebhook.Get(new  GetSecondLimitReachedRequest(list.SuccessfulResult.Webhooks.First().Id));

                    Assert.IsTrue(result.IsSuccess);
                }

            }
        }


        [TestMethod]
        public async Task TestFirstReachedWebhook()
        {
            var apiKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new AdminKey(apiKey), httpClient))
            {
                var result = await api.SecondLimitReachedWebhook.Test();

                Assert.IsTrue(result.IsSuccess);
            }
        }

        [TestMethod]
        public async Task ListSecondReachedWebhook()
        {
            var apiKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new AdminKey(apiKey), httpClient))
            {
                var result = await api.SecondLimitReachedWebhook.List();

                Assert.IsTrue(result.IsSuccess);
            }
        }

        [TestMethod]
        public async Task AddFirstReachedWebhook()
        {

            var apiKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new AdminKey(apiKey), httpClient))
            {
                var request = new AddSecondLimitReachedWebhookRequest("https://getaddress.io/webhook");

                var result = await api.SecondLimitReachedWebhook.Add(request);

                Assert.IsTrue(result.IsSuccess);

                var deleteResult = await api.SecondLimitReachedWebhook.Remove(result.SuccessfulResult.Id);

                Assert.IsTrue(deleteResult.IsSuccess);
            }
        }
    }
}
