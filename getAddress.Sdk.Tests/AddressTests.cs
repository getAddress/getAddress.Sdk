﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using getAddress.Sdk;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using getAddress.Sdk.Api;
using System.Net.Http;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public async Task GetAddressViaService()
        {
            var apiKey = KeyHelper.GetApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            var addressService = new AddressService(apiKey, httpClient);

            var result = await addressService.Get(new GetAddressRequest("CO91PU",house: "M.J.R. Site Solutions Ltd"));

            Assert.IsTrue(result.IsSuccess);
        }

        [TestMethod]
        public async Task GetAddress()
        {
            var apiKey = KeyHelper.GetApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddressApi(new ApiKey(apiKey), httpClient))
            {
                var result = await api.Address.Get(new GetAddressRequest("NN13ER"));

                Assert.IsTrue(result.IsSuccess);

            }
        }


        [TestMethod]
        public async Task GetExpandedAddress()
        {
            var apiKey = KeyHelper.GetApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new ApiKey(apiKey),httpClient))
            {
                var result = await api.Address.GetExpanded(new GetAddressRequest("NN13ER"));

                Assert.IsTrue(result.IsSuccess);
            }
        }

        [TestMethod]
        public async Task GetExpandedAddressWithHouse()
        {
            var apiKey = KeyHelper.GetApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new ApiKey(apiKey), httpClient))
            {
                var result = await api.Address.GetExpanded(new GetAddressRequest("NN13ER",house:"6"));

                Assert.IsTrue(result.IsSuccess);
            }
        }

        [TestMethod]
        public async Task GetPlaceDetails()
        {
            var apiKey = KeyHelper.GetApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            var addressService = new AddressService(apiKey, httpClient);

            var googleApiKey = new GoogleApiKey(KeyHelper.GetGoogleApiKey());

            var googlePlaceId = KeyHelper.GetGooglePlaceId();

            var result = await addressService.PlaceDetails(new PlaceDetailsRequest(googlePlaceId, googleApiKey));

            Assert.IsTrue(result.IsSuccess);
        }

        [TestMethod]
        public async Task GetAddress_Sort()
        {
            var apiKey = KeyHelper.GetApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new ApiKey(apiKey), httpClient))
            {
                var result = await api.Address.Get(new GetAddressRequest("PE150SR", sort: true));

                Assert.IsTrue(result.IsSuccess);
            }
        }

        [TestMethod]
        public async Task GetAddress_Fuzzy()
        {
            var apiKey = KeyHelper.GetApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new ApiKey(apiKey), httpClient))
            {
                var result = await api.Address.Get(new GetAddressRequest("PE150SR",house: "Ltd", fuzzy: true));

                Assert.IsTrue(result.IsSuccess);
            }
        }


        [TestMethod]
        public async Task GetAddress_Sort_With_House()
        {
            var apiKey = KeyHelper.GetApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new ApiKey(apiKey), httpClient))
            {
                var result = await api.Address.Get(new GetAddressRequest("PE150SR", house:"1", sort: true));

                Assert.IsTrue(result.IsSuccess);
            }
        }



    }
}
