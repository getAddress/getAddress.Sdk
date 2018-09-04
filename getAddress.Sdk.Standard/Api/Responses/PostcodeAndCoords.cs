using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Responses
{
    public class PostcodeAndCoords
    {
        [JsonProperty("postcode")]
        public string EmailAddress { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

    }

}


