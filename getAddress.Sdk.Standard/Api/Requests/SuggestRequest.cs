using Newtonsoft.Json;


namespace getAddress.Sdk.Api.Requests
{
    public class SuggestRequest
    {
        [JsonProperty("term")]
        public string Term { get; set; }

        [JsonProperty("top")]
        public  int Top { get; set; }

        [JsonProperty("all")]
        public bool All { get; set; }

        [JsonProperty("filter")]
        public SuggestFilter Filter { get; set; } = new SuggestFilter();
    }

    public class SuggestFilter
    {

        [JsonProperty("locality")]
        public string Locality
        {
            get; set;
        }


        [JsonProperty("district")]
        public string District
        {
            get; set;
        }

        [JsonProperty("county")]
        public string County
        {
            get; set;
        }

        [JsonProperty("thoroughfare")]
        public string Thoroughfare
        {
            get; set;
        }

        [JsonProperty("town_or_city")]
        public string TownOrCity
        {
            get;set;
        }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }


        [JsonProperty("residential")]
        public bool? Residential { get; set; }

        [JsonProperty("radius")]
        public Radius Radius { get; set; } = new Radius();
    }


    public class Radius
    {

        [JsonProperty("km")]
        public int? Km
        {
            get;set;
        }

        [JsonProperty("latitude")]
        public double? Latitude
        {
            get;set;
        }

        [JsonProperty("longitude")]
        public double? Longitude
        {
            get;set;
        }

    }

}


   
