using getAddress.Sdk.Api.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class FirstLimitReachedWebhookTests
    {

        [TestMethod]
        public async Task GetFirstReachedWebhook() {
           
            var apiKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new AdminKey(apiKey),httpClient))
            {
                var list = await api.FirstLimitReachedWebhook.List();
                
                Assert.IsTrue(list.IsSuccess);

                if (list.SuccessfulResult.Webhooks.Any())
                {
                    var result = await api.FirstLimitReachedWebhook.Get(new GetFirstLimitReachedRequest(list.SuccessfulResult.Webhooks.First().Id));

                    Assert.IsTrue(result.IsSuccess);
                }
                
            }
        }

        [TestMethod]
        public async Task TestFirstReachedWebhook()
        {
            var apiKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new AdminKey(apiKey),httpClient))
            {
                var result = await api.FirstLimitReachedWebhook.Test();

                Assert.IsTrue(result.IsSuccess);
            }
        }

      

        [TestMethod]
        public async Task ListFirstReachedWebhook() {
            var apiKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new AdminKey(apiKey),httpClient))
            {
                var result = await api.FirstLimitReachedWebhook.List();

                Assert.IsTrue(result.IsSuccess);
            }
        }

        [TestMethod]
        public async Task AddFirstReachedWebhook() {
            
            var apiKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new AdminKey(apiKey),httpClient))
            {
                var request = new AddFirstLimitReachedWebhookRequest("https://getaddress.io/webhook");

                var result = await api.FirstLimitReachedWebhook.Add(request);

                Assert.IsTrue(result.IsSuccess);

                var deleteResult = await api.FirstLimitReachedWebhook.Remove(result.SuccessfulResult.Id);

                Assert.IsTrue(deleteResult.IsSuccess);
            }
        }
    }
}
