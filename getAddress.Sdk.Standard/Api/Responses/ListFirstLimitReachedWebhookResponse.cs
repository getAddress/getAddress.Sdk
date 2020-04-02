using System.Collections.Generic;
using System.Linq;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListFirstLimitReachedWebhookResponse: ResponseBase<
        ListFirstLimitReachedWebhookResponse.Success,
        ListFirstLimitReachedWebhookResponse.Failed, 
        ListFirstLimitReachedWebhookResponse.TokenExpired,
        ListFirstLimitReachedWebhookResponse.RateLimitedReached,
        ListFirstLimitReachedWebhookResponse.Forbidden>
    {

        protected ListFirstLimitReachedWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess):base(statusCode,reasonPhrase,raw,isSuccess)
        {
        
        }

        public class Success: ListFirstLimitReachedWebhookResponse
        {
            public IEnumerable<FirstLimitReachedWebhook> Webhooks { get; }

            public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<FirstLimitReachedWebhook> webhooks) :base(statusCode, reasonPhrase, raw,true)
            {
                Webhooks = webhooks;
                SuccessfulResult = this;
            }
        }

        public class Failed : ListFirstLimitReachedWebhookResponse
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
                FailedResult = this;
                TokenExpiredResult = this;
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
