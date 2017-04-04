using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class ListTests
    {

        [TestMethod]
        public async Task ListDomains()
        {
            var adminKey = KeyHelper.GetAdminKey();

            using (var api = new GetAddesssApi(new AdminKey(adminKey)))
            {
                var result = await api.DomainWhitelist.List();

                Assert.IsTrue(result.IsSuccess);
            }
             
        }

        [TestMethod]
        public async Task ListIpAddress()
        {
            var adminKey = KeyHelper.GetAdminKey();

            using (var api = new GetAddesssApi(new AdminKey(adminKey)))
            {
                var result = await api.IpAddressWhitelist.List();

                Assert.IsTrue(result.IsSuccess);
            }

        }
    }
}
