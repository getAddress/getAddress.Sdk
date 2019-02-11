using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Requests
{
    public class RemoveFirstLimitReachedWebhookRequest: IRemoveWebhookRequest
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

        public static implicit operator RemoveFirstLimitReachedWebhookRequest(int id)
        {
            return new RemoveFirstLimitReachedWebhookRequest(id);
        }
    }

}
