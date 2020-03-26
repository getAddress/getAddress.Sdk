using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api;
using getAddress.Sdk.Api.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class PermissionTests
    {

        [TestMethod]
        public async Task GivenAValidToken_ListReturnsSuccessfulResult()
        {
            var accessToken = await TokenHelper.GetAccessToken();

            var httpClient = HttpClientHelper.ForStagingServer();

            var service = new PermissionService(accessToken, httpClient);

            var listResponse = await service.List();

            Assert.IsTrue(listResponse.IsSuccess);
        }

        [TestMethod]
        public async Task Add_Get_Update_Delete()
        {

            var adminKey = KeyHelper.GetAdminKey();
            var emailAddress = "support@getaddress.io";

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            var permissionService = new PermissionService(adminKey, httpClient);

            var addResponse = await permissionService.Add(new AddPermissionRequest(emailAddress, new PermissionRequest(false, false, false)));

            Assert.IsTrue(addResponse.IsSuccess);

            var getResponse = await permissionService.Get(new GetPermissionRequest(emailAddress));

            Assert.IsTrue(getResponse.IsSuccess);

            var listResponse = await permissionService.List();

            Assert.IsTrue(listResponse.IsSuccess && listResponse.SuccessfulResult.Permissions.Any());

            var updateResponse = await permissionService.Update(new UpdatePermissionRequest(emailAddress, new PermissionRequest(true, true, true)));

            Assert.IsTrue(updateResponse.IsSuccess);

            var getResponse2 = await permissionService.Get(new GetPermissionRequest(emailAddress));

            Assert.IsTrue(getResponse2.IsSuccess);

            var deleteResponse = await permissionService.Remove(new RemovePermissionRequest(emailAddress));

            Assert.IsTrue(deleteResponse.IsSuccess);
        }



    }
}
