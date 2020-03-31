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

            Func<int, string, string, GetTokenResponse> success = (statusCode, phrase, json) =>
            {
                var tokens = GetTokens(json);

                return new GetTokenResponse.Success(statusCode, phrase, json, tokens.Tokens.Access, tokens.Tokens.Refresh);
            };

            Func<string, string, GetTokenResponse> tokenExpired = (rp, b) => { return new GetTokenResponse.TokenExpired(rp, b); };
            Func<string, string, double, GetTokenResponse> limitReached = (rp, b, r) => { return new GetTokenResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, GetTokenResponse> failed = (sc, rp, b) => { return new GetTokenResponse.Failed(sc, rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed);

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

            Func<int, string, string, RefreshTokenResponse> success = (statusCode, phrase, json) =>
            {
                var tokenContainer = GetTokens(json);

                return new RefreshTokenResponse.Success(statusCode, phrase, json, tokenContainer.Tokens.Access, tokenContainer.Tokens.Refresh);
            };

            Func<string, string, RefreshTokenResponse> tokenExpired = (rp, b) => { return new RefreshTokenResponse.TokenExpired(rp, b); };
            Func<string, string, double, RefreshTokenResponse> limitReached = (rp, b, r) => { return new RefreshTokenResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, RefreshTokenResponse> failed = (sc, rp, b) => { return new RefreshTokenResponse.Failed(sc, rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed);

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

            Func<int, string, string, RevokeTokenResponse> success = (statusCode, phrase, json) =>
            {
                return new RevokeTokenResponse.Success(statusCode, phrase, json);
            };

            Func<string, string, RevokeTokenResponse> tokenExpired = (rp, b) => { return new RevokeTokenResponse.TokenExpired(rp, b); };
            Func<string, string, double, RevokeTokenResponse> limitReached = (rp, b, r) => { return new RevokeTokenResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, RevokeTokenResponse> failed = (sc, rp, b) => { return new RevokeTokenResponse.Failed(sc, rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed);
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
