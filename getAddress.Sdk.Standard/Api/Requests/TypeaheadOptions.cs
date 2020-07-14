using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace getAddress.Sdk.Api.Requests
{
    public class TypeaheadOptions
    {

        [JsonProperty("top")]
        public int Top { get; set; }

        [JsonProperty("filter")]
        public TypeaheadFilter Filter { get; set; } = new TypeaheadFilter();

        [JsonProperty("search")]
        public string[] Search { get; set; } = new string[0];

    }


    public class TypeaheadFilter
    {

        [JsonProperty("locality")]
        public string Locality
        {
            get;
            set;
        }

      
        [JsonProperty("district")]
        public string District
        {
            get;
            set;
        }


        [JsonProperty("county")]
        public string County
        {
            get;
            set;
        }


        [JsonProperty("town_or_city")]
        public string TownOrCity
        {
            get;
            set;
        }


        [JsonProperty("postcode")]
        public string Postcode { get; set; }


        [JsonProperty("residential")]
        public bool? Residential { get; set; }
    }

}
