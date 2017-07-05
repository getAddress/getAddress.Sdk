using Newtonsoft.Json;


namespace getAddress.Sdk.Api.Requests
{
    public class GetAddressRequest
    {
        [JsonProperty("postcode")]
        public string Postcode
        {
            get;
        }

        [JsonProperty("house")]
        public string House
        {
            get;
        }


        public GetAddressRequest(string postcode,string house = null)
        {
            Postcode = postcode;
            House = house;
        }

    }
}
