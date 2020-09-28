using System.Threading.Tasks;
using getAddress.Sdk.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class BillingAddressTests
    {

        [TestMethod]
        public async Task GivenAValidToken_SubscriptionReturnsSuccessfulResult()
        {
            var accessToken = await TokenHelper.GetAccessToken();

            var httpClient = HttpClientHelper.ForStagingServer();

            var service = new BillingAddressService(httpClient);

            var response = await service.Get(accessToken);

            Assert.IsTrue(response.IsSuccess);
        }

        [TestMethod]
        public async Task GivenAValidToken_UpdateReturnsSuccessfulResult()
        {
            var accessToken = await TokenHelper.GetAccessToken();

            var httpClient = HttpClientHelper.ForStagingServer();

            var service = new BillingAddressService(httpClient);

            var response = await service.Update(new Api.Requests.BillingAddressRequest("Codeberry Limited","28b Newgate String","Doddington", "March", "Cambs","PE15 0SR"), accessToken);

            Assert.IsTrue(response.IsSuccess);
        }
    }
}
