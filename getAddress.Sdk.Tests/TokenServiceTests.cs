using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using getAddress.Sdk.Api;
using System.Net.Http;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class TokenServiceTests
    {
        [TestMethod]
        public async Task GetTokenService()
        {
            var apiKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            var tokenService = new TokenService(apiKey, httpClient);

            var tokenResponse = await tokenService.Get();

            Assert.IsTrue(tokenResponse.IsSuccess);
        }

        [TestMethod]
        public async Task RefreshTokenService()
        {
            var apiKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            var tokenService = new TokenService(apiKey, httpClient);

            var tokenResponse = await tokenService.Get();

            Assert.IsTrue(tokenResponse.IsSuccess);

            var success = tokenResponse.SuccessfulResult;

            var refreshTokenResponse = await tokenService.Refresh(success.RefreshToken);

            Assert.IsTrue(refreshTokenResponse.IsSuccess);
        }

        [TestMethod]
        public async Task RevokeTokenService()
        {
            var apiKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            var tokenService = new TokenService(apiKey, httpClient);

            var revokeResponse = await tokenService.Revoke();

            Assert.IsTrue(revokeResponse.IsSuccess);
        }
    }
}
