using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class SuggestTests
    {
        [TestMethod]
        public async Task Get_Returns_Successful_Result()
        {
            var apiKey = KeyHelper.GetApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new ApiKey(apiKey), httpClient))
            {
                var result = await api.Suggest.Get(new SuggestRequest { Term = "codeberry" });

                Assert.IsTrue(result.IsSuccess);

                var addressResult = await api.Get.Address(result.SuccessfulResult.Suggestions.First());

                Assert.IsTrue(addressResult.IsSuccess);
            }
        }

        //todo: filter
        //todo: top 
    }
}
