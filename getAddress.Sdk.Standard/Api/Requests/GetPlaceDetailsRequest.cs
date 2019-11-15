using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Requests
{
    public class PlaceDetailsRequest
    {
        [JsonProperty("google-place-id")]
        public GooglePlaceId PlaceId { get; }


        [JsonProperty("google-api-key")]
        public GoogleApiKey GoogleApiKey
        {
            get;
        }

        public PlaceDetailsRequest(GooglePlaceId placeId, GoogleApiKey googleApiKey)
        {
            PlaceId = placeId;
            GoogleApiKey = googleApiKey;
        }
    }
}


   
