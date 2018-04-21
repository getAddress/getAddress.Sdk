using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Requests
{
    public class GetInvoiceRequest
    {
        public GetInvoiceRequest(string number)
        {
            Number = number;
        }

        [JsonProperty("number")]
        public string Number { get; }

        public static implicit operator GetInvoiceRequest(string number)
        {
            return new GetInvoiceRequest(number);
        }
    }
}
