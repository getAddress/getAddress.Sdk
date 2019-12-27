using getAddress.Sdk.Api;
using getAddress.Sdk.Api.Requests;
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
        public async Task Get_UsageV3()
        {
            var apiKey = KeyHelper.GetAdminKey();
            
            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            var service = new UsageService(apiKey, httpClient);

            var result = await service.GetV3();

            Assert.IsTrue(result.IsSuccess);

            var successfulResult = result.SuccessfulResult;

            var usageToday = successfulResult.Usage.UsageToday;

            var dailyLimit = successfulResult.Usage.DailyLimit;

            var monthlyBuffer = successfulResult.Usage.MonthlyBuffer;

            var monthlyBufferUsed = successfulResult.Usage.MonthlyBufferUsed;

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
