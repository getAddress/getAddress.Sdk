

namespace getAddress.Sdk.Api.Responses
{
    public class GetInvoiceCCResponse : ResponseBase<GetInvoiceCCResponse.Success, GetInvoiceCCResponse.Failed>
    {

        protected GetInvoiceCCResponse(int statusCode, string reasonPhase, string raw, bool isSuccess)
            : base(statusCode, reasonPhase, raw, isSuccess)
        {


        }

        public class Success : GetInvoiceCCResponse
        {
            public InvoiceCC InvoiceCC { get; }


            internal Success(int statusCode, string reasonPhase, string raw, InvoiceCC invoiceCC) : base(statusCode, reasonPhase, raw, true)
            {
                InvoiceCC = invoiceCC;
                this.SuccessfulResult = this;
            }
        }

        public class Failed : GetInvoiceCCResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                this.FailedResult = this;
            }
        }
    }
}

