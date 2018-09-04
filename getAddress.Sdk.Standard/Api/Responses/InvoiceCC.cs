using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Responses
{
    public class InvoiceCC
    {
        internal static InvoiceCC Blank(long id)
        {
            var invoiceCC = new InvoiceCC(id, string.Empty);
            return invoiceCC;
        }
        internal InvoiceCC()
        {

        }

         internal InvoiceCC(long id, string emailAddress)
        {

            Id = id;
            EmailAddress = emailAddress;
        }
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }
    }

}


