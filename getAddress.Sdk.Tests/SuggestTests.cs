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

        [TestMethod]
        public async Task Given_Top_Equals_2_Get_Returns_6_Suggestions()
        {
            var apiKey = KeyHelper.GetApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new ApiKey(apiKey), httpClient))
            {
                const int top = 2;

                var result = await api.Suggest.Get(new SuggestRequest { Term = "nn1 3er" });

                Assert.IsTrue(result.IsSuccess);

                Assert.IsTrue(result.SuccessfulResult.Suggestions.Count() > top);

                var result2 = await api.Suggest.Get(new SuggestRequest { Term = "nn1 3er", Top = top });

                Assert.IsTrue(result2.IsSuccess);

                Assert.IsTrue(result2.SuccessfulResult.Suggestions.Count() == top);
            }
        }

        [TestMethod]
        public async Task Given_Northamptonshire_County_Filter_Get_Returns_Only_Suggestions_From_Northampton()
        {
            var apiKey = KeyHelper.GetApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new ApiKey(apiKey), httpClient))
            {
                var request = new  SuggestRequest
                {
                    Term = "nn1 3er"
                };

                request.Filter.County = "Cambridgeshire";

                var result = await api.Suggest.Get(request);

                Assert.IsTrue(result.IsSuccess);

                Assert.IsTrue(!result.SuccessfulResult.Suggestions.Any());

                var request2 = new SuggestRequest
                {
                    Term = "nn1 3er"
                };

                request2.Filter.County = "Northamptonshire";

                var result2 = await api.Suggest.Get(request2);

                Assert.IsTrue(result2.IsSuccess);

                Assert.IsTrue(result2.SuccessfulResult.Suggestions.Any());

            }
        }


        [TestMethod]
        public async Task Given_Westminster_District_County_Filter_Get_Returns_Only_Suggestions_From_Westminster()
        {
            var apiKey = KeyHelper.GetApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new ApiKey(apiKey), httpClient))
            {
                var term = "W1H 2LJ";
                var request = new SuggestRequest
                {
                    Term = term
                };

                request.Filter.District = "Warminster";

                var result = await api.Suggest.Get(request);

                Assert.IsTrue(result.IsSuccess);

                Assert.IsTrue(!result.SuccessfulResult.Suggestions.Any());

                var request2 = new SuggestRequest
                {
                    Term = term
                };

                request2.Filter.District = "Westminster";

                var result2 = await api.Suggest.Get(request2);

                Assert.IsTrue(result2.IsSuccess);

                Assert.IsTrue(result2.SuccessfulResult.Suggestions.Any());

            }
        }

        [TestMethod]
        public async Task Given_Radius_Filter_Get_Returns_Only_Suggestions_WithIn_Radius()
        {
            var apiKey = KeyHelper.GetApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new ApiKey(apiKey), httpClient))
            {
                var request = new SuggestRequest
                {
                    Term = "codeberry"
                };

                request.Filter.Radius.Km = 2;
                request.Filter.Radius.Latitude = 52.24092483520508;
                request.Filter.Radius.Longitude = -0.8780822157859801;

                var result = await api.Suggest.Get(request);

                Assert.IsTrue(result.IsSuccess);

                Assert.IsTrue(!result.SuccessfulResult.Suggestions.Any());

                var request2 = new SuggestRequest
                {
                    Term = "codeberry"
                };

                request2.Filter.Radius.Km = 2;
                request2.Filter.Radius.Latitude = 52.493823;
                request2.Filter.Radius.Longitude = 0.054798;

                var result2 = await api.Suggest.Get(request2);

                Assert.IsTrue(result2.IsSuccess);

                Assert.IsTrue(result2.SuccessfulResult.Suggestions.Any());

            }
        }
    }
}
