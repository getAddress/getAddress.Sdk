namespace getAddress.Sdk.Api.Responses
{
    public abstract class GetWebhookResponse : ResponseBase<
        GetWebhookResponse.Success, 
        GetWebhookResponse.Failed, 
        GetWebhookResponse.TokenExpired,
        GetWebhookResponse.RateLimitedReached>
    {
        protected GetWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public GetFirstLimitReachedWebhookResponse FormerResult()
        {
            if (this.IsSuccess)
            {
                return new GetFirstLimitReachedWebhookResponse.Success(SuccessfulResult.StatusCode,
                    SuccessfulResult.ReasonPhrase, SuccessfulResult.Raw, SuccessfulResult.Webhook.Id,SuccessfulResult.Webhook.Url);
            }

            return new GetFirstLimitReachedWebhookResponse.Failed(FailedResult.StatusCode, FailedResult.ReasonPhrase, FailedResult.Raw);
        }

        public GetSecondLimitReachedWebhookResponse FormerResult2()
        {
            if (this.IsSuccess)
            {
                return new GetSecondLimitReachedWebhookResponse.Success(SuccessfulResult.StatusCode,
                    SuccessfulResult.ReasonPhrase, SuccessfulResult.Raw, SuccessfulResult.Webhook.Id, SuccessfulResult.Webhook.Url);
            }

            return new GetSecondLimitReachedWebhookResponse.Failed(FailedResult.StatusCode, FailedResult.ReasonPhrase, FailedResult.Raw);
        }

        public class Success : GetWebhookResponse
        {
            public Webhook Webhook { get; }

            public Success(int statusCode, string reasonPhrase, string raw, Webhook webhook) : base(statusCode, reasonPhrase, raw, true)
            {
                Webhook = webhook;
                SuccessfulResult = this;
            }

            public Success(int statusCode, string reasonPhrase, string raw, int id, string url) : this(statusCode, reasonPhrase, raw, new Webhook
            {
                Id = id,
                Url = url
            })
            {

            }
        }


        public class Failed : GetWebhookResponse
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
