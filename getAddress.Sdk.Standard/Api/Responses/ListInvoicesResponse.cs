using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListInvoicesResponse: ResponseBase<ListInvoicesResponse.Success,ListInvoicesResponse.Failed>
    {
        protected ListInvoicesResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess):base(statusCode,reasonPhrase,raw,isSuccess)
        {
        
        }
        public class Success: ListInvoicesResponse
        {
            public IEnumerable<Invoice> Invoices { get; }

            public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<Invoice> invoices) :base(statusCode, reasonPhrase, raw,true)
            {
                Invoices = invoices;
                SuccessfulResult = this;
            }
        }
        public class Failed : ListInvoicesResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) :base(statusCode, reasonPhrase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}
