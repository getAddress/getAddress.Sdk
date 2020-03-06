

namespace getAddress.Sdk.Api.Responses
{
    public class GetInvoiceCCResponse : ResponseBase<GetInvoiceCCResponse.Success, GetInvoiceCCResponse.Failed>
    {

        protected GetInvoiceCCResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess)
            : base(statusCode, reasonPhrase, raw, isSuccess)
        {


        }

        public class Success : GetInvoiceCCResponse
        {
            public InvoiceCC InvoiceCC { get; }


            internal Success(int statusCode, string reasonPhrase, string raw, InvoiceCC invoiceCC) : base(statusCode, reasonPhrase, raw, true)
            {
                InvoiceCC = invoiceCC;
                this.SuccessfulResult = this;
            }
        }

        public class Failed : GetInvoiceCCResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                this.FailedResult = this;
            }
        }
    }
}

