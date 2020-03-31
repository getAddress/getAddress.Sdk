namespace getAddress.Sdk.Api.Responses
{
    public abstract class AddInvoiceCCResponse : ResponseBase<AddInvoiceCCResponse.Success, 
        AddInvoiceCCResponse.Failed,AddInvoiceCCResponse.TokenExpired, AddInvoiceCCResponse.RateLimitedReached>
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
            internal static Failed NewFailed(int statusCode, string reasonPhrase, string raw)
            {
                return new Failed(statusCode, reasonPhrase, raw);
            }
        }
        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                TokenExpiredResult = this;
                IsTokenExpired = true;
            }

            internal static TokenExpired NewTokenExpired(string reasonPhrase, string raw)
            {
                return new TokenExpired(reasonPhrase, raw);
            }
        }

        public class RateLimitedReached : Failed
        {
            public double RetryAfterSeconds { get; }
            public RateLimitedReached(string reasonPhrase, string raw, double retryAfterSeconds) : base(429, reasonPhrase, raw)
            {
                RetryAfterSeconds = retryAfterSeconds;
                RateLimitReachedResult = this;
                IsRateLimitReached = true;
            }
            internal static RateLimitedReached NewRateLimitedReached(string reasonPhrase, string raw, double retryAfterSeconds)
            {
                return new RateLimitedReached(reasonPhrase, raw, retryAfterSeconds);
            }
        }
    }
}
