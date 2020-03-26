using System;
using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api;
using getAddress.Sdk.Api.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class InvoiceCCTests
    {

        [TestMethod]
        public async Task GivenAValidToken_ListReturnsSuccessfulResult()
        {
            var accessToken = await TokenHelper.GetAccessToken();

            var httpClient = HttpClientHelper.ForStagingServer();

            var service = new InvoiceEmailCcService(accessToken, httpClient);

            var listResponse = await service.List();

            Assert.IsTrue(listResponse.IsSuccess);
        }

        [TestMethod]
        public  async Task All_Methods()
        {
            var apiKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new AdminKey(apiKey),httpClient))
            {
                var addResult = await api.InvoiceCC.Add(new AddInvoiceCCRequest("test@test.com"));

                Assert.IsTrue(addResult.IsSuccess);

                var getResult = await api.InvoiceCC.Get(addResult.SuccessfulResult.Id);

                Assert.IsTrue(getResult.IsSuccess);

                var listResult = await api.InvoiceCC.List();

                Assert.IsTrue(listResult.IsSuccess);

                var deleteResult = await api.InvoiceCC.Remove(addResult.SuccessfulResult.Id);

                Assert.IsTrue(deleteResult.IsSuccess);

            }
        }
    }
}
