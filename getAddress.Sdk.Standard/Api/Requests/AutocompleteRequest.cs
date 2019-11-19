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

        [JsonProperty("ip-address")]
        public IpAddress IpAddress
        {
            get;
            set;
        }


        public AutocompleteRequest(string input, GoogleApiKey googleApiKey, SessionToken sessionToken = null, IpAddress ipAddress = null)
        {
            Input = input;
            GoogleApiKey = googleApiKey;
            SessionToken = sessionToken;
            IpAddress = ipAddress;
        }
    }
}


   
