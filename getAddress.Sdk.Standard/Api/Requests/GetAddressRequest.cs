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

        [JsonProperty("sort")]
        public bool Sort
        {
            get;
        }


        public GetAddressRequest(string postcode,string house = null, bool sort = false)
        {
            Postcode = postcode;
            House = house;
            Sort = sort;
        }

    }
}


   
