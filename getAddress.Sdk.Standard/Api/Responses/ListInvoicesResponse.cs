
using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListInvoicesResponse: ResponseBase<ListInvoicesResponse.Success,ListInvoicesResponse.Failed>
    {
        protected ListInvoicesResponse(int statusCode, string reasonPhase, string raw, bool isSuccess):base(statusCode,reasonPhase,raw,isSuccess)
        {
        
        }
        public class Success: ListInvoicesResponse
        {
            public IEnumerable<Invoice> Invoices { get; }

            internal Success(int statusCode, string reasonPhase, string raw, IEnumerable<Invoice> invoices) :base(statusCode, reasonPhase, raw,true)
            {
                Invoices = invoices;
                SuccessfulResult = this;
            }
        }
        public class Failed : ListInvoicesResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) :base(statusCode, reasonPhase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}
