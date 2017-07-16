using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using getAddress.Sdk;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public async Task GetAddress()
        {
            var apiKey = KeyHelper.GetApiKey();

            using (var api = new GetAddesssApi(new ApiKey(apiKey)))
            {
                var result = await api.Address.Get(new GetAddressRequest("NN13ER"));

                Assert.IsTrue(result.IsSuccess);
            }
        }

        [TestMethod]
        public async Task GetAddress_Sort()
        {
            var apiKey = KeyHelper.GetApiKey();

            using (var api = new GetAddesssApi(new ApiKey(apiKey)))
            {
                var result = await api.Address.Get(new GetAddressRequest("PE150SR", sort: true));

                Assert.IsTrue(result.IsSuccess);
            }
        }


        [TestMethod]
        public async Task GetAddress_Sort_With_House()
        {
            var apiKey = KeyHelper.GetApiKey();

            using (var api = new GetAddesssApi(new ApiKey(apiKey)))
            {
                var result = await api.Address.Get(new GetAddressRequest("PE150SR", house:"1", sort: true));

                Assert.IsTrue(result.IsSuccess);
            }
        }


        [TestMethod]
        public async Task GetAddress2()
        {
            var adminKey = new AdminKey("Your Admin Key");

            using (var api = new GetAddesssApi(adminKey))
            {
                var result = await api.Usage.Get();

                if (result.IsSuccess)
                {
                    var successfulResult = (GetUsageResponse.Success)result;

                    var count = successfulResult.Usage.Count;

                    var limit1 = successfulResult.Usage.Limit1;

                    var limit2 = successfulResult.Usage.Limit2;
                }
            }
        }

    }
}
