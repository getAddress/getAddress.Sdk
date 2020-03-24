using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class DistanceApi: ApiKeyBase
    {
        public const string Path = "distance/";

        internal DistanceApi(ApiKey  apiKey, GetAddesssApi api) : base(apiKey,api)
        {

        }

        public async Task<DistanceResponse> Get(DistanceRequest request)
        {
            return await Get(Api, Path, this.ApiKey, request);
        }

        public async static Task<DistanceResponse> Get(GetAddesssApi api, string path, ApiKey apiKey, DistanceRequest request)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));


            api.SetAuthorizationKey(apiKey);

            var fullPath = $"{path}{request.PostcodeFrom}/{request.PostcodeTo}";

            var response = await api.Get(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var distance = Distance.FromJson(body);

                return new DistanceResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, distance);
            }
            if (response.HasTokenExpired())
            {
                return new DistanceResponse.TokenExpired(response.ReasonPhrase, body);
            }

            return new DistanceResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

    }
}
