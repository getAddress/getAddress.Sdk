using Newtonsoft.Json;
using System;


namespace getAddress.Sdk.Api.Requests
{
    public class RemoveDomainWhitelistRequest
    {
        [JsonProperty("id")]
        public string Id
        {
            get;
        }
        public RemoveDomainWhitelistRequest(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            Id = id;
        }
    }
}
