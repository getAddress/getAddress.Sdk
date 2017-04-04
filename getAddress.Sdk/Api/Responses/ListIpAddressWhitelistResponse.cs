

using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListIpAddressWhitelistResponse: AdminResponse
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
            }
        }

        public class Failed : ListIpAddressWhitelistResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) :base(statusCode, reasonPhase, raw, false)
            {

            }
        }
    }
}
