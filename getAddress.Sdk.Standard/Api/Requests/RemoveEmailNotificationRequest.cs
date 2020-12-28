using Newtonsoft.Json;
namespace getAddress.Sdk.Api.Requests
{
    public class RemoveEmailNotificationRequest
    {
        [JsonProperty("id")]
        public long Id
        {
            get;
        }
        public RemoveEmailNotificationRequest(long id)
        {
            Id = id;
        }

    }
}
