

using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListDomainWhitelistResponse: AdminResponse
    {

        protected ListDomainWhitelistResponse(int statusCode, string reasonPhase, string raw, bool isSuccess):base(statusCode,reasonPhase,raw,isSuccess)
        {
        
        }

        public class Success: ListDomainWhitelistResponse
        {
            public IEnumerable<DomainWhitelist> DomainWhitelists { get; }

            internal Success(int statusCode, string reasonPhase, string raw, IEnumerable<DomainWhitelist> domainWhitelists) :base(statusCode, reasonPhase, raw,true)
            {
                DomainWhitelists = domainWhitelists;
            }
        }

        public class Failed : ListDomainWhitelistResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) :base(statusCode, reasonPhase, raw, false)
            {

            }
        }
    }
}
