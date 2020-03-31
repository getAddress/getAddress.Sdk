namespace getAddress.Sdk.Api.Responses
{
    public abstract class RemoveWebhookResponse : ResponseBase<
        RemoveWebhookResponse.Success, 
        RemoveWebhookResponse.Failed,
        RemoveWebhookResponse.TokenExpired,
        RemoveWebhookResponse.RateLimitedReached>
    {

        protected RemoveWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : RemoveWebhookResponse
        {
            public string Message { get; set; }

            public Success(int statusCode, string reasonPhrase, string raw, string message) : base(statusCode, reasonPhrase, raw, true)
            {
                SuccessfulResult = this;
                Message = message;
            }
        }

        internal RemoveFirstLimitReachedWebhookResponse FormerResult()
        {
            if (this.IsSuccess)
            {
                return new RemoveFirstLimitReachedWebhookResponse.Success(SuccessfulResult.StatusCode,
                    SuccessfulResult.ReasonPhrase, SuccessfulResult.Raw, this.SuccessfulResult.Message);
            }
            else
            {
                return new RemoveFirstLimitReachedWebhookResponse.Failed(SuccessfulResult.StatusCode,
                    SuccessfulResult.ReasonPhrase, SuccessfulResult.Raw);
            }
        }

        internal RemoveSecondLimitReachedWebhookResponse FormerResult2()
        {
            if (this.IsSuccess)
            {
                return new RemoveSecondLimitReachedWebhookResponse.Success(SuccessfulResult.StatusCode,
                    SuccessfulResult.ReasonPhrase, SuccessfulResult.Raw, this.SuccessfulResult.Message);
            }
            else
            {
                return new RemoveSecondLimitReachedWebhookResponse.Failed(FailedResult.StatusCode,
                    FailedResult.ReasonPhrase, FailedResult.Raw);
            }

        }

        public class Failed : RemoveWebhookResponse
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
