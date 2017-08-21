using Newtonsoft.Json;



namespace getAddress.Sdk.Api.Requests
{
    public class RemoveFirstLimitReachedWebhookRequest
    {
        [JsonProperty("id")]
        public int Id
        {
            get;
        }
        public RemoveFirstLimitReachedWebhookRequest(int id)
        {
            Id = id;
        }
    }
}
