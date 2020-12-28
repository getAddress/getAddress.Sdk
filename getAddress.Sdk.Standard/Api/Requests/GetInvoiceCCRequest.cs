using Newtonsoft.Json;


namespace getAddress.Sdk.Api.Requests
{

    public class GetInvoiceCCRequest
    {
        public GetInvoiceCCRequest(long id)
        {
            Id = id;
        }

        [JsonProperty("id")]
        public long Id { get; }

        public static implicit operator GetInvoiceCCRequest(long id)
        {
            return new GetInvoiceCCRequest(id);
        }
    }
}
