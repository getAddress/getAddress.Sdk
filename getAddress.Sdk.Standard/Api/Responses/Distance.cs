using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Responses
{
    public class Distance
    {

        [JsonProperty("metres")]
        public double Metres { get; set; }

        [JsonProperty("from")]
        public PostcodeAndCoords From { get; set; }

        [JsonProperty("to")]
        public PostcodeAndCoords To { get; set; }

        public Distance()
        {

        }

        internal static Distance FromJson(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new Distance();

            return JsonConvert.DeserializeObject<Distance>(body);
        }

    }

}


