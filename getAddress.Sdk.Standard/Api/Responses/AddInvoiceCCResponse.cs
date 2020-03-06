namespace getAddress.Sdk.Api.Responses
{
    public abstract class AddInvoiceCCResponse : ResponseBase<AddInvoiceCCResponse.Success, AddInvoiceCCResponse.Failed>
    {
        protected AddInvoiceCCResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {
        }

        public class Success : AddInvoiceCCResponse
        {
            public string Message { get; }

            public long Id { get; }

            internal Success(int statusCode, string reasonPhrase, string raw, string message, long id) : base(statusCode, reasonPhrase, raw, true)
            {
                Message = message;
                Id = id;
                SuccessfulResult = this;
            }
        }

        public class Failed : AddInvoiceCCResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}
