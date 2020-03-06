using getAddress.Sdk.Api;
using getAddress.Sdk.Api.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;



namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class ExpiredWebhookTests
    {

        [TestMethod]
        public async Task GetWebhook()
        {
            var apiKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new AdminKey(apiKey),httpClient))
            {
                var addResult = await api.ExpiredWebhook.Add("https://enow375xiqy9k.x.pipedream.net/");

                Assert.IsTrue(addResult.IsSuccess);

                var getResult = await api.ExpiredWebhook.Get(addResult.SuccessfulResult.Id);

                Assert.IsTrue(getResult.IsSuccess);

                var listResult = await api.ExpiredWebhook.List();

                Assert.IsTrue(listResult.IsSuccess && listResult.SuccessfulResult.Webhooks.Any());

                var testResult = await api.ExpiredWebhook.Test();

                Assert.IsTrue(testResult.IsSuccess);

                var removeResult = await api.ExpiredWebhook.Remove(addResult.SuccessfulResult.Id);

                Assert.IsTrue(removeResult.IsSuccess);
            }
        }

        [TestMethod]
        public async Task GetAddressExpiredWebhook()
        {
            var adminKey = KeyHelper.GetAdminKey();

            IWebhookService getAddressExpiredWebhook =  new ExpiredWebhookService(adminKey);

            await GetAddressExpiredWebhookTest(adminKey, getAddressExpiredWebhook);

        }

        private async Task GetAddressExpiredWebhookTest(AdminKey adminKey, IWebhookService getAddressExpiredWebhook)
        {
            var addResult = await getAddressExpiredWebhook.Add("https://enow375xiqy9k.x.pipedream.net/");

            Assert.IsTrue(addResult.IsSuccess);

            var getResult = await getAddressExpiredWebhook.Get( addResult.SuccessfulResult.Id);

            Assert.IsTrue(getResult.IsSuccess);

            var listResult = await getAddressExpiredWebhook.List();

            Assert.IsTrue(listResult.IsSuccess && listResult.SuccessfulResult.Webhooks.Any());

            var testResult = await getAddressExpiredWebhook.Test();

            Assert.IsTrue(testResult.IsSuccess);

            var removeResult = await getAddressExpiredWebhook.Remove( addResult.SuccessfulResult.Id);

            Assert.IsTrue(removeResult.IsSuccess);
        }


    }
}
