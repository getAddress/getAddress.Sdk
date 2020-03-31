
namespace getAddress.Sdk.Api.Responses
{
    public class PrivateAddress: Address
    {
        public string Id { get; set; }
    }

    public class GetPrivateAddressResponse : ResponseBase<
        GetPrivateAddressResponse.Success,
        GetPrivateAddressResponse.Failed, 
        GetPrivateAddressResponse.TokenExpired,
        GetPrivateAddressResponse.RateLimitedReached>
    {

        protected GetPrivateAddressResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {
        }

        public class Success : GetPrivateAddressResponse
        {
            public PrivateAddress PrivateAddress { get; }

            public Success(int statusCode, string reasonPhrase, string raw, PrivateAddress privateAddress) : base(statusCode, reasonPhrase, raw, true)
            {
                PrivateAddress = privateAddress;
                SuccessfulResult = this;
            }
            public Success(int statusCode, string reasonPhrase, string raw, string id,
                string line1, string line2, string line3, string line4, string locality, string townOrCity, string county) : this(statusCode, reasonPhrase, raw,
                    new PrivateAddress
                    {
                        Id = id,
                        Line1 = line1,
                        Line2 = line2,
                        Line3 = line3,
                        Line4 = line4,
                        Locality = locality,
                        TownOrCity = townOrCity,
                        County = county
                    })
            {
               
            }

            internal static Success NewSuccess(int statusCode, string reasonPhrase, string raw, PrivateAddress privateAddress)
            {
                return new Success(statusCode, reasonPhrase, raw, privateAddress);
            }
        }

        public class Failed : GetPrivateAddressResponse
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
                return new TokenExpired( reasonPhrase, raw);
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

            internal static RateLimitedReached NewRateLimitedReached(string reasonPhrase, string raw,int retryAfterSeconds)
            {
                return new RateLimitedReached(reasonPhrase, raw, retryAfterSeconds);
            }
        }
    }
}
