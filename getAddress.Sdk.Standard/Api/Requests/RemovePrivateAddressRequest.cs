using Newtonsoft.Json;


namespace getAddress.Sdk.Api.Requests
{
    public class RemovePrivateAddressRequest
    {
        [JsonProperty("id")]
        public string Id
        {
            get;
        }

        [JsonProperty("postcode")]
        public string Postcode
        {
            get;
        }

        public RemovePrivateAddressRequest(string postcode, string id)
        {
            Postcode = postcode;
            Id = id;
        }
    }
}
