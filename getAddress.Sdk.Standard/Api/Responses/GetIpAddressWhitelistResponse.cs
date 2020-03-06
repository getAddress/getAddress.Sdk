

namespace getAddress.Sdk.Api.Responses
{
    public class IpAddressWhitelist 
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }

    public abstract class GetIpAddressWhitelistResponse: ResponseBase<GetIpAddressWhitelistResponse.Success,GetIpAddressWhitelistResponse.Failed>
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
        }
    }
}
