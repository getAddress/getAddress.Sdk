using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public async Task GetAddress()
        {
            var apiKey = KeyHelper.GetApiKey();

            using (var api = new GetAddesssApi(new ApiKey(apiKey)))
            {
                var result = await api.Address.Get(new GetAddressRequest("NN13ER"));

                Assert.IsTrue(result.IsSuccess);
            }
        }
    }
}
