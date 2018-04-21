

namespace getAddress.Sdk.Api.Responses
{

    public class GetInvoiceResponse : ResponseBase<GetInvoiceResponse.Success,GetInvoiceResponse.Failed>
    {

        protected GetInvoiceResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) 
            : base(statusCode, reasonPhase, raw, isSuccess)
        {

            
        }

        public class Success : GetInvoiceResponse
        {
            public Invoice Invoice { get; }
            

            internal Success(int statusCode, string reasonPhase, string raw, Invoice invoice) : base(statusCode, reasonPhase, raw, true)
            {
                Invoice = invoice;
                this.SuccessfulResult = this;
            }
        }

        public class Failed : GetInvoiceResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                this.FailedResult = this;
            }
        }
    }

}

