using getAddress.Sdk.Api.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
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

            using (var api = new GetAddesssApi(new AdminKey(apiKey)))
            {
                var result = await api.FirstLimitReachedWebhook.Get(new GetFirstLimitReachedRequest(13));

                Assert.IsTrue(result.IsSuccess);
            }
        }


          [TestMethod]
        public async Task DeleteFirstReachedWebhook() {
            var apiKey = KeyHelper.GetAdminKey();

            using (var api = new GetAddesssApi(new AdminKey(apiKey)))
            {
                var result = await api.FirstLimitReachedWebhook.Remove(new RemoveFirstLimitReachedWebhookRequest(13));

                Assert.IsTrue(result.IsSuccess);
            }
        }

        [TestMethod]
        public async Task ListFirstReachedWebhook() {
            var apiKey = KeyHelper.GetAdminKey();

            using (var api = new GetAddesssApi(new AdminKey(apiKey)))
            {
                var result = await api.FirstLimitReachedWebhook.List();

                Assert.IsTrue(result.IsSuccess);
            }
        }

         [TestMethod]
        public async Task AddFirstReachedWebhook() {
            var apiKey = KeyHelper.GetAdminKey();

            using (var api = new GetAddesssApi(new AdminKey(apiKey)))
            {
                var request = new AddFirstLimitReachedWebhookRequest("https://getaddress.io/webhook");

                var result = await api.FirstLimitReachedWebhook.Add(request);

                Assert.IsTrue(result.IsSuccess);
            }
        }
    }
}
