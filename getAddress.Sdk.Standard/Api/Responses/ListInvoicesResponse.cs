using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListInvoicesResponse: ResponseBase<
        ListInvoicesResponse.Success,
        ListInvoicesResponse.Failed, 
        ListInvoicesResponse.TokenExpired,
        ListInvoicesResponse.RateLimitedReached,
        ListInvoicesResponse.Forbidden>
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

        public class Forbidden : Failed
        {
            public Forbidden(string reasonPhrase, string raw) : base(403, reasonPhrase, raw)
            {
                ForbiddenResult = this;
                IsForbidden = true;
            }
        }

    }
}
