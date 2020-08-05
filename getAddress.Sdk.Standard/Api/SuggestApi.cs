using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class SuggestApi: ApiKeyBase 
    {
        public const string Path = "suggest/";

        internal SuggestApi(ApiKey apiKey, GetAddesssApi api) : base(apiKey, api)
        {

        }

        public async Task<SuggestResponse> Get(SuggestRequest request)
        {
            return await Get(Api, Path, this.ApiKey, request);
        }

        public async static Task<SuggestResponse> Get(GetAddesssApi api, string path, ApiKey apiKey, SuggestRequest request, CancellationToken cancellationToken = default)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
            if (request == null) throw new ArgumentNullException(nameof(request));

            var fullPath = Path + request.Term;

            api.SetAuthorizationKey(apiKey);

            var response = await api.Post(fullPath, request,cancellationToken:cancellationToken);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, SuggestResponse> success = (statusCode, phrase, json) =>
            {
                var suggestions = GetSuggestions(body);

                return new SuggestResponse.Success(statusCode, phrase, json,suggestions.Suggestions);
            };

            Func<string, string, SuggestResponse> tokenExpired = (rp, b) => { return new SuggestResponse.TokenExpired(rp, b); };
            Func<string, string, SuggestResponse> forbidden = (rp, b) => { return new SuggestResponse.Forbidden(rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                SuggestResponse.RateLimitedReached.NewRateLimitedReached,
                SuggestResponse.Failed.NewFailed,
                forbidden
                );

        }


        private static SuggestionList GetSuggestions(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new SuggestionList();

            return JsonConvert.DeserializeObject<SuggestionList>(body);
        }
    }
}
