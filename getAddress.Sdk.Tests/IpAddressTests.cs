using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Net.Http;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class IpAddressTest
    {


        [TestMethod]
        public async Task GivenAValidToken_ListReturnsSuccessfulResult()
        {
            var accessToken = await TokenHelper.GetAccessToken();

            var httpClient = HttpClientHelper.ForStagingServer();

            var service = new IpAddressWhitelistService(accessToken, httpClient);

            var listResponse = await service.List();

            Assert.IsTrue(listResponse.IsSuccess);
        }

        [TestMethod]
        public async Task Get()
        {
            var apiKey = KeyHelper.GetAdminKey();
            
            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new AdminKey(apiKey), httpClient))
            {
                var addResult = await api.IpAddressWhitelist.Add(new AddIpAddressWhitelistRequest("192.168.1.0"));

                Assert.IsTrue(addResult.IsSuccess);

                var result = await api.IpAddressWhitelist.Get(addResult.SuccessfulResult.Id);

                Assert.IsTrue(result.IsSuccess);

                var listResult = await api.IpAddressWhitelist.List();

                Assert.IsTrue(listResult.IsSuccess);

                var deleteResult = await api.IpAddressWhitelist.Remove(addResult.SuccessfulResult.Id);

                Assert.IsTrue(deleteResult.IsSuccess);

            }
        }
    }
}
