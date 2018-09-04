using System;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class DistanceTests
    {

        [TestMethod]
        public async Task Should_Return_Expected_Distance()
        {
            var apiKey = KeyHelper.GetApiKey();

            using (var api = new GetAddesssApi(new ApiKey(apiKey)))
            {
                var result = await api.Distance.Get(new DistanceRequest("nn13er","nn13er")); 

                Assert.IsTrue(result.IsSuccess);

            }
        }
    }
}
