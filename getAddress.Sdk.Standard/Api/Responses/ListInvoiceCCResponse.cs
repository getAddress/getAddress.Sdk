using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListInvoiceCCResponse : ResponseBase<ListInvoiceCCResponse.Success, 
        ListInvoiceCCResponse.Failed,  ListInvoiceCCResponse.TokenExpired>
    {

        protected ListInvoiceCCResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : ListInvoiceCCResponse
        {
            public IEnumerable<InvoiceCC> InvoiceCCs { get; }

            public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<InvoiceCC> invoiceCCs) : base(statusCode, reasonPhrase, raw, true)
            {
                InvoiceCCs = invoiceCCs;
                SuccessfulResult = this;
            }
        }

        public class Failed : ListInvoiceCCResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                FailedResult = this;
            }
        }
        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                FailedResult = this;
                TokenExpiredResult = this;
            }
        }
    }
}
