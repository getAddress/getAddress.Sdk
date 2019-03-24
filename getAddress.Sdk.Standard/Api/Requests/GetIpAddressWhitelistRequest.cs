using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Requests
{
    public class GetIpAddressWhitelistRequest
    {

        public GetIpAddressWhitelistRequest(string id)
        {
            Id = id;
        }

        [JsonProperty("id")]
        public string Id { get; }

        public static implicit operator GetIpAddressWhitelistRequest(string id)
        {
            return new GetIpAddressWhitelistRequest(id);
        }
    }
    

}
