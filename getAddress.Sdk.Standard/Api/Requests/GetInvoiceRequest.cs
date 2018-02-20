using Newtonsoft.Json;


namespace getAddress.Sdk.Api.Requests
{
    public class GetInvoiceRequest
    {
        [JsonProperty("number")]
        public string Number
        {
            get;
        }

          public GetInvoiceRequest(string number)
        {
            Number = number;
        }

    }
}
