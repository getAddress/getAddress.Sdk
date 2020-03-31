

namespace getAddress.Sdk.Api.Responses
{
    public class IpAddressWhitelist 
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }

    public abstract class GetIpAddressWhitelistResponse: ResponseBase<
        GetIpAddressWhitelistResponse.Success,
        GetIpAddressWhitelistResponse.Failed,
        GetIpAddressWhitelistResponse.TokenExpired,
        GetIpAddressWhitelistResponse.RateLimitedReached>
    {

        protected GetIpAddressWhitelistResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess):base(statusCode,reasonPhrase,raw,isSuccess)
        {

        }

        public class Success: GetIpAddressWhitelistResponse
        {
            public IpAddressWhitelist IpAddressWhitelist { get; set; }

            public Success(int statusCode, string reasonPhrase, string raw,string id, string value):base(statusCode, reasonPhrase, raw,true)
            {
                IpAddressWhitelist = new IpAddressWhitelist
                {
                    Id = id,
                    Value = value
                };
                SuccessfulResult = this;
            }
        }

        public class Failed : GetIpAddressWhitelistResponse
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
