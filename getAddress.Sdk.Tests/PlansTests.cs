using getAddress.Sdk.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class PlansTests
    {

        [TestMethod]
        public async Task GetWithService()
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            var service = new PlansService(httpClient);

            var result = await service.Get();

            Assert.IsTrue(result.IsSuccess);
        }
    }
}
