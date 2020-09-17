using System;


namespace getAddress.Sdk.Api.Responses
{
    public class Plan
    {
        public decimal Amount { get; set; }

        public string Term { get; set; }

        public int DailyLookupLimit1 { get; set; }

        public int DailyLookupLimit2 { get; set; }

    }

    public class SubscriptionV2
    {
        public DateTime NextBillingDate { get; set; }

        public Plan Plan { get; set; }

        public string PaymentMethod { get; set; }

        public string Status { get; set; }
    }

    public abstract class SubscriptionV2Response : ResponseBase<
        SubscriptionV2Response.Success,
        SubscriptionV2Response.Failed,
        SubscriptionV2Response.TokenExpired,
        SubscriptionV2Response.RateLimitedReached,
        SubscriptionV2Response.Forbidden>
    {
        protected SubscriptionV2Response(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : SubscriptionV2Response
        {
            public SubscriptionV2 Subscription { get; set; }

            public Success(int statusCode, string reasonPhrase, string raw, SubscriptionV2 subscription) : base(statusCode, reasonPhrase, raw, true)
            {
                Subscription = subscription;

                SuccessfulResult = this;
            }
        }

        public class Failed : SubscriptionV2Response
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

    }
}
