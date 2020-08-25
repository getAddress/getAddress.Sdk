using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace getAddress.Sdk.Tests
{


    [TestClass]
    public class TypeaheadTests
    {

        [TestMethod]
        public async Task GivenAValidToken_ListReturnsSuccessfulResult()
        {
            var httpClient = HttpClientHelper.ForStagingServer();

            ITypeaheadService service = new TypeaheadService(httpClient);

            var apiKey = KeyHelper.GetApiKey();

            var listResponse = await service.List("pe", apiKey: apiKey);

            Assert.IsTrue(listResponse.IsSuccess);
        }


        [TestMethod]
        public async Task List_Returns_Successful_Result()
        {
            var apiKey = KeyHelper.GetApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new ApiKey(apiKey), httpClient))
            {
                var result = await api.TypeaheadApi.List("ab");

                Assert.IsTrue(result.IsSuccess);
            }
        }

        [TestMethod]
        public async Task Given_Top_2_List_Returns_Successful_Result_With_2_Results()
        {
            var apiKey = KeyHelper.GetApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new ApiKey(apiKey), httpClient))
            {
                var result = await api.TypeaheadApi.List("ab");

                Assert.IsTrue(result.IsSuccess);

                Assert.IsTrue(result.SuccessfulResult.Predictions.Count() > 2);

                var result2 = await api.TypeaheadApi.List("ab", new TypeaheadOptions { Top = 2 });

                Assert.IsTrue(result2.IsSuccess);

                Assert.IsTrue(result2.SuccessfulResult.Predictions.Count() == 2);

            }
        }


        [TestMethod]
        public async Task Given_Postcode_Filter_List_Returns_Successful_Result()
        {
            var apiKey = KeyHelper.GetApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new ApiKey(apiKey), httpClient))
            {
                var result = await api.TypeaheadApi.List("watk" , new TypeaheadOptions {
                    Filter = new TypeaheadFilter {  Postcode = "NN1 3ER" }
                });

                Assert.IsTrue(result.IsSuccess);

                Assert.IsTrue(result.SuccessfulResult.Predictions.Count() == 1);


                var result2 = await api.TypeaheadApi.List("watk", new TypeaheadOptions
                {
                    Filter = new TypeaheadFilter { Postcode = "PE15 0SR" }
                });

                Assert.IsTrue(result2.IsSuccess);

                Assert.IsTrue(result2.SuccessfulResult.Predictions.Count() == 0);


                var result3 = await api.TypeaheadApi.List("codeber", new TypeaheadOptions
                {
                    Filter = new TypeaheadFilter { Postcode = "PE15 0SR" }
                });

                Assert.IsTrue(result3.IsSuccess);

                Assert.IsTrue(result3.SuccessfulResult.Predictions.Count() == 1);
            }
        }

        [TestMethod]
        public async Task Given_Only_Postcode_Search_List_Returns_Successful_Result()
        {
            var apiKey = KeyHelper.GetApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new ApiKey(apiKey), httpClient))
            {
                var result = await api.TypeaheadApi.List("nn15sn", new TypeaheadOptions
                {
                   Search = new string[1] { "postcode"}
                });

                Assert.IsTrue(result.IsSuccess);

                Assert.IsTrue(result.SuccessfulResult.Predictions.Any());


              

            }
        }
    }
}
