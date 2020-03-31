namespace getAddress.Sdk.Api.Responses
{
    public abstract class GetFirstLimitReachedWebhookResponse : ResponseBase<
        GetFirstLimitReachedWebhookResponse.Success,
        GetFirstLimitReachedWebhookResponse.Failed,
        GetFirstLimitReachedWebhookResponse.TokenExpired,
        GetFirstLimitReachedWebhookResponse.RateLimitedReached
        >
    {

        protected GetFirstLimitReachedWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : GetFirstLimitReachedWebhookResponse
        {
            public FirstLimitReachedWebhook FirstLimitReachedWebhook { get; }

            public Success(int statusCode, string reasonPhrase, string raw, int id, string url) : base(statusCode, reasonPhrase, raw, true)
            {
                FirstLimitReachedWebhook = new FirstLimitReachedWebhook {
                     Id= id,
                     Url = url
                };
                SuccessfulResult = this;
            }
        }


        public class Failed : GetFirstLimitReachedWebhookResponse
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
