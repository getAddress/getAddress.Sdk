using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Requests
{
    public class GetDomainWhitelistRequest
    {

        public GetDomainWhitelistRequest(string id)
        {
            Id = id;
        }

        [JsonProperty("id")]
        public string Id { get; }

        public static implicit operator GetDomainWhitelistRequest(string id)
        {
            return new GetDomainWhitelistRequest(id);
        }
    }

   
}
