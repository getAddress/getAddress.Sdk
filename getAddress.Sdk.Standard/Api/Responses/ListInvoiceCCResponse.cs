using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListInvoiceCCResponse : ResponseBase<ListInvoiceCCResponse.Success, ListInvoiceCCResponse.Failed>
    {

        protected ListInvoiceCCResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        public class Success : ListInvoiceCCResponse
        {
            public IEnumerable<InvoiceCC> InvoiceCCs { get; }

            internal Success(int statusCode, string reasonPhase, string raw, IEnumerable<InvoiceCC> invoiceCCs) : base(statusCode, reasonPhase, raw, true)
            {
                InvoiceCCs = invoiceCCs;
                SuccessfulResult = this;
            }
        }

        public class Failed : ListInvoiceCCResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}
