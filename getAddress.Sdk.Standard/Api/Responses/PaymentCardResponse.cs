using Newtonsoft.Json;
using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class PaymentCardList
    {
        [JsonProperty("cards")]
        public IEnumerable<PaymentCard> Cards { get; set; } = new List<PaymentCard>();
    }
    public class PaymentCard
    {
        [JsonProperty("month_expires")]
        public int MonthExpires { get; set; }

        [JsonProperty("year_expires")]
        public int YearExpires {get;set;}

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("last_four_digits")]
        public int LastFourDigits { get; set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

    }

    public abstract class PaymentCardResponse : ResponseBase<
        PaymentCardResponse.Success,
        PaymentCardResponse.Failed,
        PaymentCardResponse.TokenExpired,
        PaymentCardResponse.RateLimitedReached,
        PaymentCardResponse.Forbidden>
    {
        protected PaymentCardResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : PaymentCardResponse
        {
            public PaymentCardList PaymentCards { get; set; }

            public Success(int statusCode, string reasonPhrase, string raw, PaymentCardList paymentCards) : base(statusCode, reasonPhrase, raw, true)
            {
                PaymentCards = paymentCards;

                SuccessfulResult = this;
            }
        }

        public class Failed : PaymentCardResponse
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
