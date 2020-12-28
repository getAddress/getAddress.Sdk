using Newtonsoft.Json;


namespace getAddress.Sdk.Api.Requests
{
    public class GetEmailNotificationRequest
    {
        public GetEmailNotificationRequest(long id)
        {
            Id = id;
        }

        [JsonProperty("id")]
        public long Id { get; }

    }
}
