using Newtonsoft.Json;
namespace getAddress.Sdk.Api.Requests
{
    public class AddExpiredCCRequest
    {
        [JsonProperty("email-address")]
        public string EmailAddress
        {
            get;
        }
        public AddExpiredCCRequest(string emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public static implicit operator AddExpiredCCRequest(string emailAddress)
        {
            return new AddExpiredCCRequest(emailAddress);
        }
    }
}
