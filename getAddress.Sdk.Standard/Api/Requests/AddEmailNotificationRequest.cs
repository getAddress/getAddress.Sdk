using Newtonsoft.Json;
namespace getAddress.Sdk.Api.Requests
{
    public class AddEmailNotificationRequest
    {
        [JsonProperty("email-address")]
        public string EmailAddress
        {
            get;
        }
        public AddEmailNotificationRequest(string emailAddress)
        {
            EmailAddress = emailAddress;
        }
    }
}
