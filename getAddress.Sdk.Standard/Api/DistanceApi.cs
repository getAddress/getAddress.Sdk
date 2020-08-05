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

            var response = await api.HttpGet(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, DistanceResponse> success = (statusCode, phrase, json) =>
            {
                var distance = Distance.FromJson(json);

                return new DistanceResponse.Success(statusCode, phrase, json, distance);
            };

            Func<string, string, DistanceResponse> tokenExpired = (rp, b) => { return new DistanceResponse.TokenExpired(rp, b); };
            Func<string, string, double, DistanceResponse> limitReached = (rp, b, r) => { return new DistanceResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, DistanceResponse> failed = (sc, rp, b) => { return new DistanceResponse.Failed(sc, rp, b); };
            Func<string, string, DistanceResponse> forbidden = (rp, b) => { return new DistanceResponse.Forbidden(rp, b); };

            return response.GetResponse( body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden
                );

        }

    }
}
