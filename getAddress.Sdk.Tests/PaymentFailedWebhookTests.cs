using getAddress.Sdk.Api.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class PaymentFailedWebhookTests
    {

        [TestMethod]
        public async Task GetWebhook()
        {
            var apiKey = KeyHelper.GetAdminKey();

            using (var api = new GetAddesssApi(new AdminKey(apiKey)))
            {
                var addResult = await api.PaymentFailedWebhook.Add("https://enx4uqjelvo0p.x.pipedream.net/");

                Assert.IsTrue(addResult.IsSuccess);

                var getResult = await api.PaymentFailedWebhook.Get(addResult.SuccessfulResult.Id);

                Assert.IsTrue(getResult.IsSuccess);

                var listResult = await api.PaymentFailedWebhook.List();

                Assert.IsTrue(listResult.IsSuccess && listResult.SuccessfulResult.Webhooks.Any());

                var testResult = await api.PaymentFailedWebhook.Test();

                Assert.IsTrue(testResult.IsSuccess);

                var removeResult = await api.PaymentFailedWebhook.Remove(addResult.SuccessfulResult.Id);

                Assert.IsTrue(removeResult.IsSuccess);
            }
        }


       
    }
}
