using System;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class InvoiceCCTests
    {
        [TestMethod]
        public  async Task All_Methods()
        {
            var apiKey = KeyHelper.GetAdminKey();

            using (var api = new GetAddesssApi(new AdminKey(apiKey)))
            {
                var getResult = await api.InvoiceCC.Get(1);

                Assert.IsTrue(getResult.IsSuccess);

                var listResult = await api.InvoiceCC.List();

                Assert.IsTrue(listResult.IsSuccess);

                var addResult = await api.InvoiceCC.Add(new AddInvoiceCCRequest("test@test.com"));

                Assert.IsTrue(addResult.IsSuccess);

                var deleteResult = await api.InvoiceCC.Remove(addResult.SuccessfulResult.Id);

            }
        }
    }
}
