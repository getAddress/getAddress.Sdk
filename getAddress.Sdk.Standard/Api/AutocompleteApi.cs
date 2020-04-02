using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{

    public class AutocompleteApi:ApiKeyBase
    {
        public const string Path = "google/autocomplete/";
        public AutocompleteApi(ApiKey apiKey, GetAddesssApi api):base(apiKey,api)
        {

        }

        public async Task<AutocompletePostcodeResponse> Postcodes(AutocompleteRequest request)
        {
            return await Postcodes(Api, Path, this.ApiKey, request);
        }

        public async static Task<AutocompletePostcodeResponse> Postcodes(GetAddesssApi api, string path, ApiKey apiKey,  AutocompleteRequest request)
        {
            return await GetPostcodeResponse(api, path, apiKey, request);
        }

        public async Task<AutocompleteResponse> Places(AutocompleteRequest request)
        {
            return await Places(Api, Path, this.ApiKey, request);
        }

        public async static Task<AutocompleteResponse> Places(GetAddesssApi api, string path, ApiKey apiKey, AutocompleteRequest request)
        {
            return await GetResponse(api, path, apiKey, request);
        }

        private async static Task<AutocompletePostcodeResponse> GetPostcodeResponse(GetAddesssApi api, string path, ApiKey apiKey, AutocompleteRequest request)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
            if (request == null) throw new ArgumentNullException(nameof(request));

            var fullPath = $"{path}postcodes/{request.Input}?google-api-key={request.GoogleApiKey.Value}";

            fullPath = AddSessionToken(fullPath, request);
            fullPath = AddIpAddress(fullPath, request);

            api.SetAuthorizationKey(apiKey);

            var response = await api.Get(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, AutocompletePostcodeResponse> success = (statusCode, phrase, json) =>
            {
                var predictions = GetPostcodePredictions(json);

                return new AutocompletePostcodeResponse.Success(statusCode, phrase, json, predictions);
            };

            Func<string, string, AutocompletePostcodeResponse> tokenExpired = (rp, b) => { return new AutocompletePostcodeResponse.TokenExpired(rp, b); };
            Func<string, string, double, AutocompletePostcodeResponse> limitReached = (rp, b, r) => { return new AutocompletePostcodeResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, AutocompletePostcodeResponse> failed = (sc, rp, b) => { return new AutocompletePostcodeResponse.Failed(sc, rp, b); };
            Func<string, string, AutocompletePostcodeResponse> forbidden = (rp, b) => { return new AutocompletePostcodeResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden
                );

        }

        private async static Task<AutocompleteResponse> GetResponse(GetAddesssApi api, string path, ApiKey apiKey, AutocompleteRequest request)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
            if (request == null) throw new ArgumentNullException(nameof(request));

            var fullPath = $"{path}places/{request.Input}?google-api-key={request.GoogleApiKey.Value}";

            fullPath = AddSessionToken(fullPath, request);
            fullPath = AddIpAddress(fullPath, request);

            api.SetAuthorizationKey(apiKey);

            var response = await api.Get(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, AutocompleteResponse> success = (statusCode, phrase, json) =>
            {
                var predictions = GetPredictions(json);

                return new AutocompleteResponse.Success(statusCode, phrase, json, predictions);
            };

            Func<string, string, AutocompleteResponse> tokenExpired = (rp, b) => { return new AutocompleteResponse.TokenExpired(rp, b); };
            Func<string, string, double, AutocompleteResponse> limitReached = (rp, b, r) => { return new AutocompleteResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, AutocompleteResponse> failed = (sc, rp, b) => { return new AutocompleteResponse.Failed(sc, rp, b); };
            Func<string, string, AutocompleteResponse> forbidden = (rp, b) => { return new AutocompleteResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden
                );

        }

        private static IEnumerable<Prediction> GetPredictions(string json)
        {
            var obj = JsonConvert.DeserializeObject<dynamic>(json);
            var predictions = new List<Prediction>();

            foreach(var prediction in obj.predictions)
            {
                string description = prediction.description;
                string googlePlaceId = prediction.google_place_id;
                
                predictions.Add(new Prediction { 
                Description = description,
                GooglePlaceId = new GooglePlaceId(googlePlaceId)
                });
            }

            return predictions;
        }

        private static IEnumerable<PostcodePrediction> GetPostcodePredictions(string json)
        {
            var obj = JsonConvert.DeserializeObject<dynamic>(json);
            var predictions = new List<PostcodePrediction>();

            foreach (var prediction in obj.predictions)
            {
                string description = prediction.description;
                string postcode = prediction.postcode;

                predictions.Add(new PostcodePrediction
                {
                    Description = description,
                    Postcode = postcode
                });
            }

            return predictions;
        }

        private static string AddSessionToken(string fullPath, AutocompleteRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.SessionToken?.Value))
            {
                fullPath += $"&session-token={request.SessionToken.Value}";
            }
            return fullPath;
        }

        private static string AddIpAddress(string fullPath, AutocompleteRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.IpAddress?.Value))
            {
                fullPath += $"&ip-address={request.IpAddress.Value}";
            }
            return fullPath;
        }


    }
}
