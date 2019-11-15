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

            api.SetAuthorizationKey(apiKey);

            var response = await api.Get(fullPath);

            var json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var predictions = GetPostcodePredictions(json);

                return new AutocompletePostcodeResponse.Success((int)response.StatusCode, response.ReasonPhrase, json, predictions);
            }

            return new AutocompletePostcodeResponse.Failed((int)response.StatusCode, response.ReasonPhrase, json);
        }

        private async static Task<AutocompleteResponse> GetResponse(GetAddesssApi api, string path, ApiKey apiKey, AutocompleteRequest request)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
            if (request == null) throw new ArgumentNullException(nameof(request));

            var fullPath = $"{path}places/{request.Input}?google-api-key={request.GoogleApiKey.Value}";

            fullPath = AddSessionToken(fullPath, request);

            api.SetAuthorizationKey(apiKey);

            var response = await api.Get(fullPath);

            var json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var predictions = GetPredictions(json);

                return new AutocompleteResponse.Success((int)response.StatusCode, response.ReasonPhrase, json, predictions);
            }

            return new AutocompleteResponse.Failed((int)response.StatusCode, response.ReasonPhrase, json);
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

    }
}
