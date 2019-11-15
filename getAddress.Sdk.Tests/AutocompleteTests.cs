﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class AutocompleteTests
    {
        [TestMethod]
        public async Task Postcodes()
        {
            var apiKey = KeyHelper.GetApiKey();

            var googleApiKey = KeyHelper.GetGoogleApiKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            var autocompleteService = new AutocompleteService(apiKey, httpClient);

            var sessionToken = new SessionToken(Guid.NewGuid().ToString());

            var result = await autocompleteService.Postcodes(new Api.Requests.AutocompleteRequest("pe15 0", new GoogleApiKey(googleApiKey), sessionToken: sessionToken));

            Assert.IsTrue(result.IsSuccess);
        }

        [TestMethod]
        public async Task Places()
        {
            
            var apiKey = KeyHelper.GetApiKey();

            var googleApiKey = KeyHelper.GetGoogleApiKey();

            var httpClient = new HttpClient();
            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            var autocompleteService = new AutocompleteService(apiKey, httpClient);

            var result = await autocompleteService.Palaces(new Api.Requests.AutocompleteRequest("adaptive", new GoogleApiKey(googleApiKey)));

            Assert.IsTrue(result.IsSuccess);

        }
    }
}
