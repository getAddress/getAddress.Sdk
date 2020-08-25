using getAddress.Sdk.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class SuggestLimitReachedWebhookTests
    {
        [TestMethod]
        public async Task GivenAValidToken_ListReturnsSuccessfulResult()
        {
            var accessToken = await TokenHelper.GetAccessToken();

            var httpClient = HttpClientHelper.ForStagingServer();

            var service = new SuggestLimitReachedWebhookService(accessToken, httpClient);

            var listResponse = await service.List();

            Assert.IsTrue(listResponse.IsSuccess);
        }

        [TestMethod]
        public async Task GetWebhook()
        {
            var apiKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            var service = new SuggestLimitReachedWebhookService(apiKey, httpClient);

            var addResult = await service.Add("https://getaddress.io/suggest-limit-reached-test");

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
