using System;
using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api;
using getAddress.Sdk.Api.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class DistanceTests
    {

        [TestMethod]
        public async Task Should_Return_Expected_Distance()
        {
            var apiKey = KeyHelper.GetApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new ApiKey(apiKey),httpClient))
            {
                var result = await api.Distance.Get(new DistanceRequest("nn13er","nn13er")); 

                Assert.IsTrue(result.IsSuccess);

            }
        }

        [TestMethod]
        public async Task Should_Return_Expected_Distance_From_Service()
        {
            var apiKey = KeyHelper.GetApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            var service = new DistanceService(apiKey, httpClient);

            var result = await service.Get(new DistanceRequest("TR19 7AA", "KW1 4YT"));

            Assert.IsTrue(result.IsSuccess);

            var successfulResult = result.SuccessfulResult;
        }
    }
}
