using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class ApiKeyApi: AdminApiBase
    {
        public const string Path = "security/api-key";

        internal ApiKeyApi(AdminKey apiKey, GetAddesssApi api) : base(apiKey,api)
        {

        }

        public async Task<ApiKeyResponse> Get()
        {
            return await Get(Api, Path, this.AdminKey);
        }

        public async static Task<ApiKeyResponse> Get(GetAddesssApi api, string path, AdminKey apiKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));

            api.SetAuthorizationKey(apiKey);

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, ApiKeyResponse> success = (statusCode, phrase, json) =>
            {
                var apiKeyModel = GetApiKey(json);

                return new ApiKeyResponse.Success(statusCode, phrase, json, apiKeyModel.ApiKey);
            };

            Func<string, string, ApiKeyResponse> tokenExpired = (rp, b) => { return new ApiKeyResponse.TokenExpired(rp, b); };
            Func<string, string,int, ApiKeyResponse> limitReached = (rp, b,r) => { return new ApiKeyResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, ApiKeyResponse> failed = (sc,rp, b) => { return new ApiKeyResponse.Failed(sc,rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed
                );
        }

        public async Task<ApiKeyResponse> Update()
        {
            return await Update(Api, Path, this.AdminKey);
        }

        public async static Task<ApiKeyResponse> Update(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
          
            api.SetAuthorizationKey(adminKey);

            var response = await api.Put(path);

            var body = await response.Content.ReadAsStringAsync();


            Func<int, string, string, ApiKeyResponse> success = (statusCode, phrase, json) =>
            {
                var model = GetApiKey(json);

                return new ApiKeyResponse.Success(statusCode, phrase, json, model.ApiKey);
            };

            Func<string, string, ApiKeyResponse> tokenExpired = (rp, b) => { return new ApiKeyResponse.TokenExpired(rp, b); };
            Func<string, string, int, ApiKeyResponse> limitReached = (rp, b, r) => { return new ApiKeyResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, ApiKeyResponse> failed = (sc, rp, b) => { return new ApiKeyResponse.Failed(sc, rp, b); };

            return response.GetResponse( body,
                success,
                tokenExpired,
                limitReached,
                failed
                );

        }


        private static ApiKeyModel GetApiKey(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new ApiKeyModel();

            return JsonConvert.DeserializeObject<ApiKeyModel>(body);
        }


        private class ApiKeyModel
        {
            [JsonProperty("api-key")]
            public string ApiKey { get; set; }
        }

    }
}
