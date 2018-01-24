

using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListIpAddressWhitelistResponse: ResponseBase<ListIpAddressWhitelistResponse.Success,ListIpAddressWhitelistResponse.Failed>
    {

        protected ListIpAddressWhitelistResponse(int statusCode, string reasonPhase, string raw, bool isSuccess):base(statusCode,reasonPhase,raw,isSuccess)
        {
        }

        public class Success: ListIpAddressWhitelistResponse
        {
            public IEnumerable<IpAddressWhitelist> IpAddressWhitelists { get; }

            internal Success(int statusCode, string reasonPhase, string raw, IEnumerable<IpAddressWhitelist> ipAddressWhitelists) :base(statusCode, reasonPhase, raw,true)
            {
                
                    IpAddressWhitelists = ipAddressWhitelists;
                    SuccessfulResult = this;
            }
        }

        public class Failed : ListIpAddressWhitelistResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) :base(statusCode, reasonPhase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}
