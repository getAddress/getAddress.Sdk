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

            if (response.IsSuccessStatusCode)
            {
                var apiKeyModel = GetApiKey(body);

                return new ApiKeyResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, apiKeyModel.ApiKey);
            }

            return new ApiKeyResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
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

            if (response.IsSuccessStatusCode)
            {
                var model = GetApiKey(body);

                return new ApiKeyResponse.Success((int)response.StatusCode, response.ReasonPhrase, body,model.ApiKey);
            }

            return new ApiKeyResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
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
