using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Requests
{
    public class UpdateEmailAddressRequest
    {
        [JsonProperty("new-email-address")]
        public string NewEmailAddress
        {
            get;
        }
        public UpdateEmailAddressRequest(string newEmailAddress)
        {
            NewEmailAddress = newEmailAddress;
        }
    }
}
