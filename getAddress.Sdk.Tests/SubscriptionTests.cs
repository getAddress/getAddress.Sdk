using System;
using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api;
using getAddress.Sdk.Api.Requests;
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
        public async Task GivenAValidToken_GetReturnsSuccessfulResult()
        {
            var accessToken = await TokenHelper.GetAccessToken();

            var httpClient = HttpClientHelper.ForStagingServer();

            var service = new SubscriptionService(httpClient);

            var response = await service.Get(accessToken);

            Assert.IsTrue(response.IsSuccess);

            var success = response.SuccessfulResult;
        }

        [TestMethod]
        public async Task GivenAValidToken_UpdateReturnsSuccessfulResult()
        {
            var accessToken = await TokenHelper.GetAccessToken();

            var httpClient = HttpClientHelper.ForStagingServer();

            var service = new SubscriptionService(httpClient);

            var request = new UpdateSubscriptionRequest
            {
                Name = Guid.NewGuid().ToString()
            };

            var response = await service.Update(request, accessToken);

            Assert.IsTrue(response.IsSuccess);

            var success = response.SuccessfulResult;
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
