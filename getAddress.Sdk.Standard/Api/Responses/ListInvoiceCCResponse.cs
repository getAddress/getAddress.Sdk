using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListInvoiceCCResponse : ResponseBase<
        ListInvoiceCCResponse.Success, 
        ListInvoiceCCResponse.Failed,  
        ListInvoiceCCResponse.TokenExpired,
        ListInvoiceCCResponse.RateLimitedReached>
    {

        protected ListInvoiceCCResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : ListInvoiceCCResponse
        {
            public IEnumerable<InvoiceCC> InvoiceCCs { get; }

            public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<InvoiceCC> invoiceCCs) : base(statusCode, reasonPhrase, raw, true)
            {
                InvoiceCCs = invoiceCCs;
                SuccessfulResult = this;
            }
        }

        public class Failed : ListInvoiceCCResponse
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
