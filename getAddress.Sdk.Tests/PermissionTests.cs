using System;
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
        public async Task Add_Get_Update_Delete()
        {
            var adminKey = KeyHelper.GetAdminKey();
            var emailAddress = "support@getaddress.io";

            var permissionService = new PermissionService(adminKey);

            var addResponse = await permissionService.Add(new AddPermissionRequest(emailAddress, new PermissionRequest(true,false)));

            Assert.IsTrue(addResponse.IsSuccess);

            var getResponse = await permissionService.Get(new GetPermissionRequest(emailAddress));

            Assert.IsTrue(getResponse.IsSuccess);

            var updateResponse = await permissionService.Update(new UpdatePermissionRequest(emailAddress, new PermissionRequest(true, true)));

            Assert.IsTrue(updateResponse.IsSuccess);

            var deleteResponse = await permissionService.Remove(new RemovePermissionRequest(emailAddress));

            Assert.IsTrue(deleteResponse.IsSuccess);

        }

        

    }
}
