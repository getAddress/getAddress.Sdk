using Newtonsoft.Json;


namespace getAddress.Sdk.Api.Requests
{
    public class BillingAddressRequest
    {
        [JsonProperty("line1")]
        public string Line1
        {
            get;
        }
        [JsonProperty("line2")]
        public string Line2
        {
            get;
        }
        [JsonProperty("line3")]
        public string Line3
        {
            get;
        }

        [JsonProperty("townOrCity")]
        public string TownOrCity { get;  }

        [JsonProperty("county")]
        public string County { get;  }

        [JsonProperty("postcode")]
        public string Postcode { get;  }


        public BillingAddressRequest(string line1, string line2, string line3, string townOrCity,
           string county, string postcode)
        {
            Line1 = line1;
            Line2 = line2;
            Line3 = line3;
            TownOrCity = townOrCity;
            County = county;
            Postcode = postcode;

        }
    }
}
