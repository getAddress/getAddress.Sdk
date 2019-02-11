using Newtonsoft.Json;


namespace getAddress.Sdk.Api.Requests
{
    public class AddWebhookRequest
    {
        [JsonProperty("url")]
        public string Url
        {
            get;
        }
        public AddWebhookRequest(string url)
        {
            Url = url;
        }

        public static implicit operator AddWebhookRequest(string url)
        {
            return new AddWebhookRequest(url);
        }
    }
}
