

using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Requests
{
    public class GetPrivateAddressRequest
    {
        [JsonProperty("postcode")]
        public string Postcode
        {
            get;
        }
        [JsonProperty("id")]
        public string Id
        {
            get;
        }

        public GetPrivateAddressRequest(string postcode, string id)
        {
            Postcode = postcode;
            Id = id;
        }
        
    }
}
