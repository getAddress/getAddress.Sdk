using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class ListPrivateAddressResponse:  ResponseBase<
        ListPrivateAddressResponse.Success,
        ListPrivateAddressResponse.Failed, 
        ListPrivateAddressResponse.TokenExpired,
        ListPrivateAddressResponse.RateLimitedReached>
    {

        protected ListPrivateAddressResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess):base(statusCode,reasonPhrase,raw,isSuccess)
        {
        }

        public class Success : ListPrivateAddressResponse
        {
            public IEnumerable<PrivateAddress> PrivateAddresses { get; }
            
            public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<PrivateAddress> privateAddresses) : base(statusCode, reasonPhrase, raw, true)
            {
                PrivateAddresses = privateAddresses;
                SuccessfulResult = this;
            }

            internal static Success NewSuccess(int statusCode, string reasonPhrase, string raw, IEnumerable<PrivateAddress> privateAddresses)
            {
                return new Success(statusCode, reasonPhrase, raw, privateAddresses);
            }
        }

        public class Failed : ListPrivateAddressResponse
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
