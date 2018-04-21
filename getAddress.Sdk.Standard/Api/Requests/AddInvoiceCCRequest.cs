using Newtonsoft.Json;


namespace getAddress.Sdk.Api.Requests
{
    public class AddInvoiceCCRequest
    {
        [JsonProperty("email_address")]
        public string EmailAddress
        {
            get;
        }
        public AddInvoiceCCRequest(string emailAddress)
        {
            EmailAddress = emailAddress;
        }
    }
}
