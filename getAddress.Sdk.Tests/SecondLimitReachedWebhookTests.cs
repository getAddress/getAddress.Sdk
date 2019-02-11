using getAddress.Sdk.Api.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class SecondLimitReachedWebhookTests
    {

        [TestMethod]
        public async Task GetSecondReachedWebhook()
        {
            var apiKey = KeyHelper.GetAdminKey();

            using (var api = new GetAddesssApi(new AdminKey(apiKey)))
            {
                var result = await api.SecondLimitReachedWebhook.Get(new GetSecondLimitReachedRequest(3));

                Assert.IsTrue(result.IsSuccess);
            }
        }


        [TestMethod]
        public async Task TestFirstReachedWebhook()
        {
            var apiKey = KeyHelper.GetAdminKey();

            using (var api = new GetAddesssApi(new AdminKey(apiKey)))
            {
                var result = await api.SecondLimitReachedWebhook.Test();

                Assert.IsTrue(result.IsSuccess);
            }
        }

        [TestMethod]
        public async Task DeleteSecondReachedWebhook()
        {
            var apiKey = KeyHelper.GetAdminKey();

            using (var api = new GetAddesssApi(new AdminKey(apiKey)))
            {
                var result = await api.SecondLimitReachedWebhook.Remove(new RemoveSecondLimitReachedWebhookRequest(1));

                Assert.IsTrue(result.IsSuccess);
            }
        }

        [TestMethod]
        public async Task ListSecondReachedWebhook()
        {
            var apiKey = KeyHelper.GetAdminKey();

            using (var api = new GetAddesssApi(new AdminKey(apiKey)))
            {
                var result = await api.SecondLimitReachedWebhook.List();

                Assert.IsTrue(result.IsSuccess);
            }
        }

        [TestMethod]
        public async Task AddSecondReachedWebhook()
        {
            var apiKey = KeyHelper.GetAdminKey();

            using (var api = new GetAddesssApi(new AdminKey(apiKey)))
            {
                var request = new AddSecondLimitReachedWebhookRequest("https://getaddress.io/webhook");

                var result = await api.SecondLimitReachedWebhook.Add(request);

                Assert.IsTrue(result.IsSuccess);
            }
        }
    }
}
