using Newtonsoft.Json;
namespace getAddress.Sdk.Api.Requests
{

    public class AddInvoiceCCRequest
    {
        [JsonProperty("email-address")]
        public string EmailAddress
        {
            get;
        }
        public AddInvoiceCCRequest(string emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public static implicit operator AddInvoiceCCRequest(string emailAddress)
        {
            return new AddInvoiceCCRequest(emailAddress);
        }
    }
}
