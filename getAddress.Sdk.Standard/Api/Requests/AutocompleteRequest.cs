using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Requests
{
    public class AutocompleteRequest
    {
        [JsonProperty("input")]
        public string Input
        {
            get;
        }

        [JsonProperty("session-token")]
        public SessionToken SessionToken
        {
            get;
            set;
        }

        [JsonProperty("google-api-key")]
        public GoogleApiKey GoogleApiKey
        {
            get;
        }

        public AutocompleteRequest(string input, GoogleApiKey googleApiKey, SessionToken sessionToken = null)
        {
            Input = input;
            GoogleApiKey = googleApiKey;
            SessionToken = sessionToken;
        }
    }
}


   
