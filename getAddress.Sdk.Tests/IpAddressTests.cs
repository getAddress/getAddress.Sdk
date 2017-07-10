using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class IpAddressTest
    {
        [TestMethod]
        public async Task Get()
        {
          
            var apiKey = KeyHelper.GetAdminKey();

            using (var api = new GetAddesssApi(new AdminKey(apiKey)))
            {
                var result = await api.IpAddressWhitelist.Get("mtkylje2oc45lja=");

                Assert.IsTrue(result.IsSuccess);
            }
        }
    }
}
