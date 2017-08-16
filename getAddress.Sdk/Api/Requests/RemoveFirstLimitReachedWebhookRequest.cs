using Newtonsoft.Json;



namespace getAddress.Sdk.Api.Requests
{
    public class RemoveFirstLimitReachedWebhookRequest
    {
        [JsonProperty("id")]
        public string Id
        {
            get;
        }
        public RemoveFirstLimitReachedWebhookRequest(string id)
        {
            Id = id;
        }
    }
}
