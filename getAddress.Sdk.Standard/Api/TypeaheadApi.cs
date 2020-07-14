using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class TypeaheadApi : ApiKeyBase
    {
        public const string Path = "typeahead/";
        public TypeaheadApi(ApiKey apiKey, GetAddesssApi api) : base(apiKey, api)
        {

        }

        public async Task<TypeaheadResponse> List(string term, TypeaheadOptions options = null)
        {
            return await List(this.Api, term, Path, this.ApiKey, options);
        }

        public async static Task<TypeaheadResponse> List(GetAddesssApi api, string term, string path, ApiKey apiKey, TypeaheadOptions options = null)
        {
            if (api is null)
            {
                throw new System.ArgumentNullException(nameof(api));
            }

            if (apiKey is null)
            {
                throw new System.ArgumentNullException(nameof(apiKey));
            }

            var fullPath = path + term;

            api.SetAuthorizationKey(apiKey);

            var response = await api.Post(fullPath, options);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, TypeaheadResponse> success = (statusCode, phrase, json) =>
            {
                var predictions = GetPredictions(json);

                return new TypeaheadResponse.Success(statusCode, phrase, json, predictions);
            };


            Func<string, string, TypeaheadResponse> forbidden = (rp, b) => { return new TypeaheadResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                TypeaheadResponse.TokenExpired.NewTokenExpired,
                TypeaheadResponse.RateLimitedReached.NewRateLimitedReached,
                TypeaheadResponse.Failed.NewFailed,
                forbidden
                );
        }


        private static IEnumerable<string> GetPredictions(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new List<string>();

            return JsonConvert.DeserializeObject<string[]>(body);

        }

    }
}
