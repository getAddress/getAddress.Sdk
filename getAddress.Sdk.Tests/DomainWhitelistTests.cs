using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class DomainWhitelistTests
    {

        [TestMethod]
        public async Task List()
        {
            var adminKey = KeyHelper.GetAdminKey();

            using (var api = new GetAddesssApi(new AdminKey(adminKey)))
            {
                var result = await api.DomainWhitelist.List();

                Assert.IsTrue(result.IsSuccess);
            }
             
        }
    }
}
