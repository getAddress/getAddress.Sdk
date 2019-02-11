using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Requests
{
    public class RemoveWebhookRequest : IRemoveWebhookRequest
    {
        [JsonProperty("id")]
        public int Id
        {
            get;
        }
        public RemoveWebhookRequest(int id)
        {
            Id = id;
        }

        public static implicit operator RemoveWebhookRequest(int id)
        {
            return new RemoveWebhookRequest(id);
        }
    }

}
