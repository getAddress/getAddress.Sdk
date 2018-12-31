using Newtonsoft.Json;


namespace getAddress.Sdk.Api.Requests
{
    public class AddSecondLimitReachedWebhookRequest
    {
        [JsonProperty("url")]
        public string Url
        {
            get;
        }
        public AddSecondLimitReachedWebhookRequest(string url)
        {
            Url = url;
        }

        public static implicit operator AddSecondLimitReachedWebhookRequest(string url)
        {
            return new AddSecondLimitReachedWebhookRequest(url);
        }
    }
}
