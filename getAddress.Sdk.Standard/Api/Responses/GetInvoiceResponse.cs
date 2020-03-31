

namespace getAddress.Sdk.Api.Responses
{

    public class GetInvoiceResponse : ResponseBase<
        GetInvoiceResponse.Success,
        GetInvoiceResponse.Failed,
        GetInvoiceResponse.TokenExpired,
        GetInvoiceResponse.RateLimitedReached>
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
            public int RetryAfterSeconds { get; }
            public RateLimitedReached(string reasonPhrase, string raw, int retryAfterSeconds) : base(429, reasonPhrase, raw)
            {
                RetryAfterSeconds = retryAfterSeconds;
                RateLimitReachedResult = this;
                IsRateLimitReached = true;
            }
            internal static RateLimitedReached NewRateLimitedReached(string reasonPhrase, string raw, int retryAfterSeconds)
            {
                return new RateLimitedReached(reasonPhrase, raw, retryAfterSeconds);
            }
        }
    }

}

