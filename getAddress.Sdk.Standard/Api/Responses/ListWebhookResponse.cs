using System.Collections.Generic;
using System.Linq;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListWebhookResponse : ResponseBase<
        ListWebhookResponse.Success, 
        ListWebhookResponse.Failed, 
        ListWebhookResponse.TokenExpired,
        ListWebhookResponse.RateLimitedReached,
        ListWebhookResponse.Forbidden>
    {

        protected ListWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public ListFirstLimitReachedWebhookResponse FormerResult()
        {
            if (this.IsSuccess)
            {
                return new ListFirstLimitReachedWebhookResponse.Success(SuccessfulResult.StatusCode,
                    SuccessfulResult.ReasonPhrase, SuccessfulResult.Raw, this.SuccessfulResult.Webhooks.Select(w => new FirstLimitReachedWebhook {
                        Id = w.Id,
                        Url = w.Url
                    }));
            }
            else
            {
                return new ListFirstLimitReachedWebhookResponse.Failed(SuccessfulResult.StatusCode,
                    SuccessfulResult.ReasonPhrase, SuccessfulResult.Raw);
            }
        }


        public class Success : ListWebhookResponse
        {
            public IEnumerable<Webhook> Webhooks { get; }

            public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<Webhook> webhooks) : base(statusCode, reasonPhrase, raw, true)
            {
                Webhooks = webhooks;
                SuccessfulResult = this;
            }
        }

        public class Failed : ListWebhookResponse
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
