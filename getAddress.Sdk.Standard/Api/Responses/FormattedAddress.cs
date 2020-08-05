

using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Responses
{
    public class FormattedAddress
    {
        [JsonProperty("line_1")]
        public string Line1 { get; set; }

        [JsonProperty("line_2")]
        public string Line2 { get; set; }

        [JsonProperty("line_3")]
        public string Line3 { get; set; }

        [JsonProperty("line_4")]
        public string Line4 { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }
    }

}
