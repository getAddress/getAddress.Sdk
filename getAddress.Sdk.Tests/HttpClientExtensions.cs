using getAddress.Sdk.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace getAddress.Sdk.Tests
{
    public static class TokenHelper
    {
        private static AccessToken accessToken = null; 

        public static async Task<AccessToken> GetAccessToken(Func<string> getKey = null)
        {
            if(accessToken == null)
            {
                getKey = getKey ?? KeyHelper.GetAdminKey;

                HttpClient httpClient = new HttpClient();

                var apiKey = getKey();

                httpClient.BaseAddress = UrlHelper.GetStagingUri();

                var tokenService = new TokenService(apiKey, httpClient);

                var tokenResponse = await tokenService.Get();

                accessToken = tokenResponse.SuccessfulResult.AccessToken;
            }

            return accessToken;
        }


    }
}
