using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using getAddress.Sdk;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using getAddress.Sdk.Api;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public async Task GetAddressViaService()
        {
            var apiKey = KeyHelper.GetApiKey();

            var addressService = new AddressService(apiKey);

            var result = await addressService.Get(new GetAddressRequest("NN13ER"));

            Assert.IsTrue(result.IsSuccess);
        }

        [TestMethod]
        public async Task GetAddress()
        {
            var apiKey = KeyHelper.GetApiKey();

            using (var api = new GetAddressApi(new ApiKey(apiKey)))
            {
                var result = await api.Address.Get(new GetAddressRequest("NN13ER"));

                Assert.IsTrue(result.IsSuccess);

            }
        }


        [TestMethod]
        public async Task GetExpandedAddress()
        {
            var apiKey = KeyHelper.GetApiKey();

            using (var api = new GetAddesssApi(new ApiKey(apiKey)))
            {
                var result = await api.Address.GetExpanded(new GetAddressRequest("NN13ER"));

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
        public async Task GetAddress_Fuzzy()
        {
            var apiKey = KeyHelper.GetApiKey();

            using (var api = new GetAddesssApi(new ApiKey(apiKey)))
            {
                var result = await api.Address.Get(new GetAddressRequest("PE150SR",house: "Ltd", fuzzy: true));

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
            var apiKey = new ApiKey("<YOUR API KEY>");

            IAddressService addresService = new AddressService(apiKey);

            var result = await addresService.Get(new GetAddressRequest("POSTCODE", "OPTIONAL HOUSE NAME"));

            if (result.IsSuccess)
            {
                var successfulResult = result.SuccessfulResult;

                var latitude = successfulResult.Latitude;

                var Longitude = successfulResult.Longitude;

                foreach (var address in successfulResult.Addresses)
                {
                    var line1 = address.Line1;
                    var line2 = address.Line2;
                    var line3 = address.Line3;
                    var line4 = address.Line4;
                    var locality = address.Locality;
                    var townOrCity = address.TownOrCity;
                    var county = address.County;
                }
            }

        }

    }
}
