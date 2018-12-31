using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Requests
{
    public class RemoveSecondLimitReachedWebhookRequest
    {
        [JsonProperty("id")]
        public int Id
        {
            get;
        }
        public RemoveSecondLimitReachedWebhookRequest(int id)
        {
            Id = id;
        }

        public static implicit operator RemoveSecondLimitReachedWebhookRequest(int id)
        {
            return new RemoveSecondLimitReachedWebhookRequest(id);
        }
    }
}
