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

    public abstract class SubscriptionResponse : ResponseBase<SubscriptionResponse.Success, SubscriptionResponse.Failed, SubscriptionResponse.TokenExpired>
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
        }

        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                FailedResult = this;
                TokenExpiredResult = this;
            }
        }
    }
}
