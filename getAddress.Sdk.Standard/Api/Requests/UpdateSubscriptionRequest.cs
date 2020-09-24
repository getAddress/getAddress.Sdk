using Newtonsoft.Json;


namespace getAddress.Sdk.Api.Requests
{
    public class UpdateSubscriptionRequest
    {
        [JsonProperty("name")]
        public string Name
        {
            get; set;
        }

    }
}
