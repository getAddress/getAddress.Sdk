namespace getAddress.Sdk.Api.Responses
{
    public abstract class GetUsageResponse : ResponseBase<
        GetUsageResponse.Success,
        GetUsageResponse.Failed, 
        GetUsageResponse.TokenExpired,
        GetUsageResponse.RateLimitedReached,
        GetUsageResponse.Forbidden>
    {

        protected GetUsageResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : GetUsageResponse
        {
            public Usage Usage { get; set; }

            public Success(int statusCode, string reasonPhrase, string raw, Usage usage) : base(statusCode, reasonPhrase, raw, true)
            {
                Usage = usage;
                SuccessfulResult = this;
            }


            public Success(int statusCode, string reasonPhrase, string raw, int counter, int limit1, int limit2) : this(statusCode, reasonPhrase, raw, 
                new Usage
            {
                Count = counter,
                Limit1 = limit1,
                Limit2 = limit2
            })
            { 
            }
        }

        public class Failed : GetUsageResponse
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
                FailedResult = this;
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
