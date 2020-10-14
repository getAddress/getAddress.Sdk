using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using getAddress.Sdk.Api;
using System.Net.Http;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class PaymentCardTests
    {
        [TestMethod]
        public async Task GetPaymentCardListWithTokenViaService()
        {
            var accessToken = await TokenHelper.GetAccessToken();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            var paymentCardService = new PaymentCardService(accessToken, httpClient);

            var result = await paymentCardService.List(accessToken);

            Assert.IsTrue(result.IsSuccess);
        }

        [TestMethod]
        public async Task AddPaymentCardWithTokenViaService()
        {
            var accessToken = await TokenHelper.GetAccessToken();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            var paymentCardService = new PaymentCardService(accessToken, httpClient);

            var result = await paymentCardService.Add(new Api.Requests.AddPaymentCardRequest("tok_1HcCQ6Her91OgW4ms9m1z002"), accessToken);

            Assert.IsTrue(result.IsSuccess);
        }
    }
}
