using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Requests
{
    public class AddPrivateAddressRequest
    {
        [JsonIgnore]
        public string Postcode
        {
            get;
        }
        [JsonProperty("line1")]
        public string Line1 { get;  }

        [JsonProperty("line2")]
        public string Line2 { get; }

        [JsonProperty("line3")]
        public string Line3 { get;  }

        [JsonProperty("line4")]
        public string Line4 { get; }

        [JsonProperty("locality")]
        public string Locality { get; }

        [JsonProperty("townOrcity")]
        public string TownOrCity { get; }

        [JsonProperty("county")]
        public string County { get;  }


        public AddPrivateAddressRequest(string postcode,string line1, string line2, string line3, string line4,
            string locality, string townOrCity, string county)
        {
            Postcode = postcode;
            Line1 = line1;
            Line2 = line2;
            Line3 = line3;
            Line4 = line4;
            Locality = locality;
            TownOrCity = townOrCity;
            County = county;

        }
    }
}
