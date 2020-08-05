using Newtonsoft.Json;


namespace getAddress.Sdk.Api.Requests
{
    public class SuggestRequest
    {
        [JsonProperty("term")]
        public string Term { get; set; }
    }
}


   
