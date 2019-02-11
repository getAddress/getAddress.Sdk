using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Requests
{
    public class GetWebhookRequest
    {

        [JsonProperty("id")]
        public int Id
        {
            get;
        }

        public GetWebhookRequest(int id)
        {
            Id = id;
        }

        public static implicit operator GetWebhookRequest(int id)
        {
            return new GetWebhookRequest(id);
        }
    }
}
