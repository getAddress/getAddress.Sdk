using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class GetAddressResponse : ResponseBase<
        GetAddressResponse.Success,
        GetAddressResponse.Failed,
        GetAddressResponse.TokenExpired,
        GetAddressResponse.RateLimitedReached>
    {
        protected GetAddressResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

            
        }

        public AccountExpired AccountExpiredResult { get; private set; }

        public NotFound NotFoundResult { get; private set; }

        public InvalidPostcode InvalidPostcodeResult { get; private set; }

        public bool TryGetExpiredResult(out AccountExpired accountExpiredResult)
        {
            if (IsExpired)
            {
                accountExpiredResult = AccountExpiredResult;
                return true;
            }

            accountExpiredResult = default;
            return false;
        }

        public bool TryGetNotFoundResult(out NotFound notFoundResult)
        {
            if (IsNotFound)
            {
                notFoundResult = NotFoundResult;
                return true;
            }

            notFoundResult = default;
            return false;
        }

        public bool TryGetInvalidPostcodeResult(out InvalidPostcode invalidPostcode)
        {
            if (IsInvalidPostcode)
            {
                invalidPostcode = InvalidPostcodeResult;
                return true;
            }

            invalidPostcode = default;
            return false;
        }

        public bool IsExpired { get; private set; }

        public bool IsNotFound { get; private set; }

        public bool IsInvalidPostcode { get; private set; }

        public class Success : GetAddressResponse
        {
            public IEnumerable<Address> Addresses { get; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }

            public Success(int statusCode, string reasonPhrase, string raw, double latitude, double longitude, IEnumerable<Address> addresses) : base(statusCode, reasonPhrase, raw, true)
            {
                Latitude = latitude;
                Longitude = longitude;
                Addresses = addresses;
                this.SuccessfulResult = this;
            }
        }

        public class Failed : GetAddressResponse 
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

        public class AccountExpired : Failed
        {
            public AccountExpired(string reasonPhrase, string raw) : base(400, reasonPhrase, raw)
            {
                AccountExpiredResult = this;
                IsExpired = true;
            }
        }

        public class NotFound : Failed
        {
            public NotFound(string reasonPhrase, string raw) : base(404, reasonPhrase, raw)
            {
                NotFoundResult = this;
                IsNotFound = true;
            }
        }

        public class InvalidPostcode : Failed
        {
            public InvalidPostcode(string reasonPhrase, string raw) : base(400, reasonPhrase, raw)
            {
                InvalidPostcodeResult = this;
                IsInvalidPostcode = true;
            }
        }

        public class RateLimitedReached : Failed
        {
            public double RetryAfterSeconds {get;}
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
