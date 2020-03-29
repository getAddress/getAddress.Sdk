namespace getAddress.Sdk.Api.Responses
{
    public abstract class AddExpiredCCResponse : ResponseBase<AddExpiredCCResponse.Success, 
        AddExpiredCCResponse.Failed, AddExpiredCCResponse.TokenExpired>
    {
        protected AddExpiredCCResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {
        }

        public class Success : AddExpiredCCResponse
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

        public class Failed : AddExpiredCCResponse
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
                TokenExpiredResult = this;
                IsTokenExpired = true;
            }
        }
    }
}
