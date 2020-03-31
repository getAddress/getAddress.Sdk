using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListDomainWhitelistResponse: ResponseBase<
        ListDomainWhitelistResponse.Success,
        ListDomainWhitelistResponse.Failed, 
        ListDomainWhitelistResponse.TokenExpired,
        ListDomainWhitelistResponse.RateLimitedReached>
    {
        protected ListDomainWhitelistResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess):base(statusCode,reasonPhrase,raw,isSuccess)
        {
        
        }

        public class Success: ListDomainWhitelistResponse
        {
            public IEnumerable<DomainWhitelist> DomainWhitelists { get; }

            public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<DomainWhitelist> domainWhitelists) :base(statusCode, reasonPhrase, raw,true)
            {
                DomainWhitelists = domainWhitelists;
                SuccessfulResult = this;
            }
        }

        public class Failed : ListDomainWhitelistResponse
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
            public int RetryAfterSeconds { get; }
            public RateLimitedReached(string reasonPhrase, string raw, int retryAfterSeconds) : base(429, reasonPhrase, raw)
            {
                RetryAfterSeconds = retryAfterSeconds;
                RateLimitReachedResult = this;
                IsRateLimitReached = true;
            }
        }
    }
}
