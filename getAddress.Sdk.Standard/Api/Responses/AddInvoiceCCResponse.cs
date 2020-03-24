namespace getAddress.Sdk.Api.Responses
{
    public abstract class AddInvoiceCCResponse : ResponseBase<AddInvoiceCCResponse.Success, 
        AddInvoiceCCResponse.Failed,AddInvoiceCCResponse.TokenExpired>
    {
        protected AddInvoiceCCResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {
        }

        public class Success : AddInvoiceCCResponse
        {
            public string Message { get; }

            public long Id { get; }

            public Success(int statusCode, string reasonPhrase, string raw, string message, long id) : base(statusCode, reasonPhrase, raw, true)
            {
                Message = message;
                Id = id;
                SuccessfulResult = this;
            }
        }

        public class Failed : AddInvoiceCCResponse
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
