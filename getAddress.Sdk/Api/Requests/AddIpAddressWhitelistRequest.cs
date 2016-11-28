using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Requests
{
    public class AddIpAddressWhitelistRequest
    {
        [JsonProperty("value")]
        public string Value
        {
            get;
        }
        public AddIpAddressWhitelistRequest(string value)
        {
            Value = value;
        }
    }
}
