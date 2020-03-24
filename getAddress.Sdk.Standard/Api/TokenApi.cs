using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class TokenApi: AdminApiBase
    {
        public const string Path = "security/token/";

        internal TokenApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey, api)
        {

        }

        public async  Task<GetTokenResponse> Get()
        {
            return await Get(Api, Path, AdminKey);
        }

        public async static Task<GetTokenResponse> Get(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var tokens = GetTokens(body);

                return new GetTokenResponse.Success((int)response.StatusCode, response.ReasonPhrase, body,tokens.Tokens.Access,tokens.Tokens.Refresh);
            }

            return new GetTokenResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        public async Task<RefreshTokenResponse> Refresh(RefreshToken refreshToken)
        {
            return await Refresh(Api, Path, refreshToken);
        }

        public async static Task<RefreshTokenResponse> Refresh(GetAddesssApi api, string path, RefreshToken refreshToken)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            
            if (refreshToken is null)
            {
                throw new ArgumentNullException(nameof(refreshToken));
            }

            var fullPath = path + "refresh";

            api.SetBearerToken(refreshToken.Value);

            var response = await api.Post(fullPath, null);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var tokenContainer = GetTokens(body);

                return new RefreshTokenResponse.Success((int)response.StatusCode, response.ReasonPhrase, body,tokenContainer.Tokens.Access, tokenContainer.Tokens.Refresh);
            }

            return new RefreshTokenResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        public async Task<RevokeTokenResponse> Revoke()
        {
            return await Revoke(Api, Path, AdminKey);
        }
        public async static Task<RevokeTokenResponse> Revoke(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));
            if (path == null) throw new ArgumentNullException(nameof(path));

            var fullPath = path + "revoke";

            api.SetAuthorizationKey(adminKey);

            var response = await api.Post(fullPath, null);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            { 
                return new RevokeTokenResponse.Success((int)response.StatusCode, response.ReasonPhrase, body);
            }

            return new RevokeTokenResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }


        private static TokensContainer GetTokens(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new TokensContainer();

            return JsonConvert.DeserializeObject<TokensContainer>(body);
        }

        private class TokensContainer
        {
            public Tokens Tokens{ get;set;}
        }
        private class Tokens
        {
            public AccessToken Access{ get; set; }
            public RefreshToken Refresh { get; set; }
        }
       
    }
}
