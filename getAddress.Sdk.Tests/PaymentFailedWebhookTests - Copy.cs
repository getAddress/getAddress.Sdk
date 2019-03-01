using getAddress.Sdk.Api.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
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

            using (var api = new GetAddesssApi(new AdminKey(apiKey)))
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


       
    }
}
