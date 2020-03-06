

using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListIpAddressWhitelistResponse: ResponseBase<ListIpAddressWhitelistResponse.Success,ListIpAddressWhitelistResponse.Failed>
    {

        protected ListIpAddressWhitelistResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess):base(statusCode,reasonPhrase,raw,isSuccess)
        {
        }

        public class Success: ListIpAddressWhitelistResponse
        {
            public IEnumerable<IpAddressWhitelist> IpAddressWhitelists { get; }

            internal Success(int statusCode, string reasonPhrase, string raw, IEnumerable<IpAddressWhitelist> ipAddressWhitelists) :base(statusCode, reasonPhrase, raw,true)
            {
                
                    IpAddressWhitelists = ipAddressWhitelists;
                    SuccessfulResult = this;
            }
        }

        public class Failed : ListIpAddressWhitelistResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) :base(statusCode, reasonPhrase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}
