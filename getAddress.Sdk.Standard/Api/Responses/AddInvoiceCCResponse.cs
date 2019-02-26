namespace getAddress.Sdk.Api.Responses
{
    public abstract class AddInvoiceCCResponse : ResponseBase<AddInvoiceCCResponse.Success, AddInvoiceCCResponse.Failed>
    {
        protected AddInvoiceCCResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {
        }

        public class Success : AddInvoiceCCResponse
        {
            public string Message { get; }

            public long Id { get; }

            internal Success(int statusCode, string reasonPhase, string raw, string message, long id) : base(statusCode, reasonPhase, raw, true)
            {
                Message = message;
                Id = id;
                SuccessfulResult = this;
            }
        }

        public class Failed : AddInvoiceCCResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}
