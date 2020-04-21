using getAddress.Sdk.Api;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class UsageWebhookTests
    {

        [TestMethod]
        public async Task GivenAValidToken_GetV3ReturnsSuccessfulResult()
        {
            var httpClient = HttpClientHelper.ForStagingServer();

            var service = new UsageService(httpClient);

            var accessToken = await TokenHelper.GetAccessToken();

            var getResponse = await service.GetV3(accessToken);

            Assert.IsTrue(getResponse.IsSuccess);
        }

        [TestMethod]
        public async Task GivenAValidToken_GetReturnsSuccessfulResult()
        {
            var accessToken = await TokenHelper.GetAccessToken();

            var httpClient = HttpClientHelper.ForStagingServer();

            var service = new UsageService(accessToken, httpClient);

            var listResponse = await service.Get();

            Assert.IsTrue(listResponse.IsSuccess);
        }

        [TestMethod]
        public async Task Usage_With_Token()
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            var accessToken = await TokenHelper.GetAccessToken();

            var usageService = new UsageService(accessToken, httpClient);
            
            var getV3result = await usageService.GetV3();

            Assert.IsTrue(getV3result.IsSuccess);

            var getResult = await usageService.Get();

            Assert.IsTrue(getResult.IsSuccess);

            var listResult = await usageService.List(new ListUsageRequest(01,01,2020,01,03,2020));

            Assert.IsTrue(listResult.IsSuccess);
        }

        [TestMethod]
        public async Task Get_UsageV3()
        {
            var apiKey = KeyHelper.GetAdminKey();
            
            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            var service = new UsageService(apiKey, httpClient);

            var result = await service.GetV3();

            Assert.IsTrue(result.IsSuccess);

            if (result.TryGetSuccess(out GetUsageV3Response.Success successfulResult))
            {
                var usageToday = successfulResult.Usage.UsageToday;

                var dailyLimit = successfulResult.Usage.DailyLimit;

                var monthlyBuffer = successfulResult.Usage.MonthlyBuffer;

                var monthlyBufferUsed = successfulResult.Usage.MonthlyBufferUsed;
            }

        }


        [TestMethod]
        public async Task Get_UsageV3_Day_Month_Year()
        {
            var apiKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            var service = new UsageService(apiKey, httpClient);

            var request = new GetUsageRequest(27, 12, 2019);

            var result = await service.GetV3(request);

            Assert.IsTrue(result.IsSuccess);
        }


    }
}
