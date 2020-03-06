using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListInvoiceCCResponse : ResponseBase<ListInvoiceCCResponse.Success, ListInvoiceCCResponse.Failed>
    {

        protected ListInvoiceCCResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : ListInvoiceCCResponse
        {
            public IEnumerable<InvoiceCC> InvoiceCCs { get; }

            internal Success(int statusCode, string reasonPhrase, string raw, IEnumerable<InvoiceCC> invoiceCCs) : base(statusCode, reasonPhrase, raw, true)
            {
                InvoiceCCs = invoiceCCs;
                SuccessfulResult = this;
            }
        }

        public class Failed : ListInvoiceCCResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}
