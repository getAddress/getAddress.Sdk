using Newtonsoft.Json;



namespace getAddress.Sdk.Api.Requests
{
    public class RemoveDomainWhitelistRequest
    {
        [JsonProperty("id")]
        public string Id
        {
            get;
        }
        public RemoveDomainWhitelistRequest(string id)
        {
            Id = id;
        }

        public static implicit operator RemoveDomainWhitelistRequest(string id)
        {
            return new RemoveDomainWhitelistRequest(id);
        }
    }
}
