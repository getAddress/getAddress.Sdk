

namespace getAddress.Sdk.Api.Responses
{
    public class DomainWhitelist
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }

    public abstract class GetDomainWhitelistResponse: ResponseBase<GetDomainWhitelistResponse.Success,
        GetDomainWhitelistResponse.Failed, GetDomainWhitelistResponse.TokenExpired>
    {

        protected GetDomainWhitelistResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess):base(statusCode,reasonPhrase,raw,isSuccess)
        {
        
        }

        public class Success: GetDomainWhitelistResponse
        {
            public DomainWhitelist DomainWhitelist { get; }

            public Success(int statusCode, string reasonPhrase, string raw, string id, string name) : base(statusCode, reasonPhrase, raw, true)
            {
                DomainWhitelist = new DomainWhitelist {
                    Id = id,
                    Name = name
                };
                SuccessfulResult = this;
            }
        }

        public class Failed : GetDomainWhitelistResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) :base(statusCode, reasonPhrase, raw, false)
            {
                   FailedResult = this;
            }
        }

        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                TokenExpiredResult = this;
                IsTokenExpired = true;
            }
        }


    }
}
