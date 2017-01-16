using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Requests
{
    public class ListPrivateAddressRequest
    {
        [JsonProperty("postcode")]
        public string Postcode { get; }

        public ListPrivateAddressRequest(string postcode)
        {
            Postcode = postcode;
        }
    }
}
