using Newtonsoft.Json;
using System;


namespace getAddress.Sdk.Api.Requests
{
    public class AddDomainWhitelistRequest
    {
        [JsonProperty("name")]
        public string Name
        {
            get;
        }
        public AddDomainWhitelistRequest(string name)
        {
            Name = name;
        }
    }
}
