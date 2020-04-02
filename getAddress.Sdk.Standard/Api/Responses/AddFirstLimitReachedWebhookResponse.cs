namespace getAddress.Sdk.Api.Responses
{
    public abstract class AddFirstLimitReachedWebhookResponse : ResponseBase<AddFirstLimitReachedWebhookResponse.Success,
        AddFirstLimitReachedWebhookResponse.Failed, 
        AddFirstLimitReachedWebhookResponse.TokenExpired,
        AddFirstLimitReachedWebhookResponse.RateLimitedReached,
        AddFirstLimitReachedWebhookResponse.Forbidden>
    {

        protected AddFirstLimitReachedWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : AddFirstLimitReachedWebhookResponse
        {
            public int Id { get; set; }

            public string Message { get; set; }

            public Success(int statusCode, string reasonPhrase, string raw,  string message,string id) : base(statusCode, reasonPhrase, raw, true)
            {
                Id = ToInt(id);
                SuccessfulResult = this;
                Message = message;
            }
        }

        public class Failed : AddFirstLimitReachedWebhookResponse
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

        public class Forbidden : Failed
        {
            public Forbidden(string reasonPhrase, string raw) : base(403, reasonPhrase, raw)
            {
                ForbiddenResult = this;
                IsForbidden = true;
            }
        }


        private int ToInt(string id) {

            if(id == null) return 0;

            return int.Parse(id);
        }
    }

}
