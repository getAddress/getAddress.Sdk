using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListIpAddressWhitelistResponse: ResponseBase<
        ListIpAddressWhitelistResponse.Success,
        ListIpAddressWhitelistResponse.Failed,
        ListIpAddressWhitelistResponse.TokenExpired,
        ListIpAddressWhitelistResponse.RateLimitedReached>
    {

        protected ListIpAddressWhitelistResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess):base(statusCode,reasonPhrase,raw,isSuccess)
        {
        }

        public class Success: ListIpAddressWhitelistResponse
        {
            public IEnumerable<IpAddressWhitelist> IpAddressWhitelists { get; }

            public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<IpAddressWhitelist> ipAddressWhitelists) :base(statusCode, reasonPhrase, raw,true)
            {
                
                    IpAddressWhitelists = ipAddressWhitelists;
                    SuccessfulResult = this;
            }
        }

        public class Failed : ListIpAddressWhitelistResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) :base(statusCode, reasonPhrase, raw, false)
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
