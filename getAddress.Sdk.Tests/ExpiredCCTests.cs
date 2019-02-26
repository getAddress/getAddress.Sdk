using System;
using System.Linq;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class ExpiredCCTests
    {
        [TestMethod]
        public  async Task All_Methods()
        {
            var apiKey = KeyHelper.GetAdminKey();

            using (var api = new GetAddesssApi(new AdminKey(apiKey)))
            {
                var listResult = await api.ExpiredCC.List();

                Assert.IsTrue(listResult.IsSuccess);

                foreach(var cc in listResult.SuccessfulResult.ExpiredCCs)
                {
                    var deleteResult = await api.ExpiredCC.Remove(cc.Id);

                    Assert.IsTrue(deleteResult.IsSuccess);
                }

                var addResult = await api.ExpiredCC.Add("test@test.com");

                Assert.IsTrue(addResult.IsSuccess);

                var getResult = await api.ExpiredCC.Get(addResult.SuccessfulResult.Id);

                Assert.IsTrue(getResult.IsSuccess);

                var listResult2 = await api.ExpiredCC.List();

                Assert.IsTrue(listResult2.IsSuccess && listResult2.SuccessfulResult.ExpiredCCs.Count() == 1);

                var deleteResult2 = await api.ExpiredCC.Remove(addResult.SuccessfulResult.Id);

                Assert.IsTrue(deleteResult2.IsSuccess);

            }
        }
    }
}
