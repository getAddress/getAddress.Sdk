using Newtonsoft.Json;



namespace getAddress.Sdk.Api.Requests
{
    public class RemoveInvoiceCCRequest
    {
        [JsonProperty("id")]
        public long Id
        {
            get;
        }
        public RemoveInvoiceCCRequest(long id)
        {
            Id = id;
        }

        public static implicit operator RemoveInvoiceCCRequest(long id)
        {
            return new RemoveInvoiceCCRequest(id);
        }
    }
}
