using System;

namespace getAddress.Sdk.Api.Responses
{
    public class Subscription
    {
        public DateTime ExpiryDate { get; set; }
        public int FirstDailyLimit { get; set; }
        public int SecondDailyLimit { get; set; }
        public decimal Amount { get; set; }
        public string Term { get; set; }
    }

    public abstract class SubscriptionResponse : ResponseBase<
        SubscriptionResponse.Success, 
        SubscriptionResponse.Failed, 
        SubscriptionResponse.TokenExpired,
        SubscriptionResponse.RateLimitedReached>
    {
        protected SubscriptionResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : SubscriptionResponse
        {
            public Subscription Subscription { get; set; }

            public Success(int statusCode, string reasonPhrase, string raw, Subscription subscription) : base(statusCode, reasonPhrase, raw, true)
            {
                Subscription = subscription;

                SuccessfulResult = this;
            }
        }

        public class Failed : SubscriptionResponse
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
