

namespace getAddress.Sdk.Api.Responses
{

    public class GetInvoiceResponse : ResponseBase<GetInvoiceResponse.Success,GetInvoiceResponse.Failed>
    {

        protected GetInvoiceResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) 
            : base(statusCode, reasonPhrase, raw, isSuccess)
        {

            
        }

        public class Success : GetInvoiceResponse
        {
            public Invoice Invoice { get; }


            public Success(int statusCode, string reasonPhrase, string raw, Invoice invoice) : base(statusCode, reasonPhrase, raw, true)
            {
                Invoice = invoice;
                this.SuccessfulResult = this;
            }
        }

        public class Failed : GetInvoiceResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                this.FailedResult = this;
            }
        }
    }

}

