using Newtonsoft.Json;
using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class SuggestionList
    {
        [JsonProperty("suggestions")]
        public IEnumerable<Suggestion> Suggestions { get; set; } = new List<Suggestion>();
    }
    public class Suggestion
    {
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
