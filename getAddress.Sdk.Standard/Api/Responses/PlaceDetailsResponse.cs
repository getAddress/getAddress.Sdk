namespace getAddress.Sdk.Api.Responses
{
    public class PlaceDetailsResponse : ResponseBase<
        PlaceDetailsResponse.Success, 
        PlaceDetailsResponse.Failed, 
        PlaceDetailsResponse.TokenExpired,
        PlaceDetailsResponse.RateLimitedReached,
        PlaceDetailsResponse.Forbidden>
    {

        protected PlaceDetailsResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {
        }

        public bool IsLimitReached { get; private set; }
        public LimitReached LimitReachedResult { get; private set; }

        public bool TryGetLimitReachedResult(out LimitReached limitReachedResult)
        {
            if (IsLimitReached)
            {
                limitReachedResult = LimitReachedResult;
                return true;
            }

            limitReachedResult = default;
            return false;
        }


        public class Success : PlaceDetailsResponse
        {
            public ExpandedAddress Address { get; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string Postcode { get; set; }

            public Success(int statusCode, string reasonPhrase, string raw, double latitude, double longitude, string postcode, ExpandedAddress address) : base(statusCode, reasonPhrase, raw, true)
            {
                Latitude = latitude;
                Longitude = longitude;
                Address = address;
                Postcode = postcode;
                this.SuccessfulResult = this;
            }
        }

        public class Failed : PlaceDetailsResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                this.FailedResult = this;
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


        public class LimitReached : Failed
        {
            public LimitReached(string reasonPhrase, string raw) : base(429, reasonPhrase, raw)
            {
                LimitReachedResult = this;
                IsLimitReached = true;
            }
        }
    }

}
