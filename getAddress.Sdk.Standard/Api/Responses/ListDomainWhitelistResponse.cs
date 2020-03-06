
using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListDomainWhitelistResponse: ResponseBase<ListDomainWhitelistResponse.Success,ListDomainWhitelistResponse.Failed>
    {

        protected ListDomainWhitelistResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess):base(statusCode,reasonPhrase,raw,isSuccess)
        {
        
        }

        public class Success: ListDomainWhitelistResponse
        {
            public IEnumerable<DomainWhitelist> DomainWhitelists { get; }

            internal Success(int statusCode, string reasonPhrase, string raw, IEnumerable<DomainWhitelist> domainWhitelists) :base(statusCode, reasonPhrase, raw,true)
            {
                DomainWhitelists = domainWhitelists;
                SuccessfulResult = this;
            }
        }

        public class Failed : ListDomainWhitelistResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) :base(statusCode, reasonPhrase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}
