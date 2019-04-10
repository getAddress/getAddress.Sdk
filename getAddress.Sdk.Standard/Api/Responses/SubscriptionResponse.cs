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

    public abstract class SubscriptionResponse : ResponseBase<SubscriptionResponse.Success, SubscriptionResponse.Failed>
    {

        protected SubscriptionResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        public class Success : SubscriptionResponse
        {
            public Subscription Subscription { get; set; }

            internal Success(int statusCode, string reasonPhase, string raw, Subscription subscription) : base(statusCode, reasonPhase, raw, true)
            {
                Subscription = subscription;

                SuccessfulResult = this;
            }
        }

        public class Failed : SubscriptionResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}
