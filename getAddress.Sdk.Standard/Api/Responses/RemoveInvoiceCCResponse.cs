
namespace getAddress.Sdk.Api.Responses
{
    public abstract class RemoveInvoiceCCResponse : ResponseBase<RemoveInvoiceCCResponse.Success, RemoveInvoiceCCResponse.Failed>
    {
        protected RemoveInvoiceCCResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : RemoveInvoiceCCResponse
        {
            public string Message { get; set; }

            internal Success(int statusCode, string reasonPhrase, string raw, string message) : base(statusCode, reasonPhrase, raw, true)
            {
                Message = message;
                SuccessfulResult = this;
            }
        }

        public class Failed : RemoveInvoiceCCResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}