using System;
using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class SubscriptionTests
    {

        [TestMethod]
        public async Task GivenAValidToken_SubscriptionReturnsSuccessfulResult()
        {
            var accessToken = await TokenHelper.GetAccessToken();

            var httpClient = HttpClientHelper.ForStagingServer();

            var service = new SubscriptionService(accessToken, httpClient);

            var listResponse = await service.Subscription();

            Assert.IsTrue(listResponse.IsSuccess);
        }

        [TestMethod]
        public async Task Unsubscribe_Fails_Without_code()
        {
            var apiKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new AdminKey(apiKey), httpClient))
            {
                var result = await api.Subscription.Unsubscribe(code: "testing");

                Assert.IsTrue(!result.IsSuccess);
            }
        }

        [TestMethod]
        public async Task Subscription()
        {
            var apiKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new AdminKey(apiKey), httpClient))
            {
                var result = await api.Subscription.Get();

                Assert.IsTrue(result.IsSuccess);
            }
        }

    }
}
