using Newtonsoft.Json;



namespace getAddress.Sdk.Api.Requests
{
    public class RemoveIpAddressWhitelistRequest
    {
        [JsonProperty("id")]
        public string Id
        {
            get;
        }
        public RemoveIpAddressWhitelistRequest(string id)
        {
            Id = id;
        }
    }
}
