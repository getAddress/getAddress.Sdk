

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListDomainWhitelistResponse: DomainWhitelistResponse
    {

        protected ListDomainWhitelistResponse(int statusCode, string reasonPhase, string raw, bool isSuccess):base(statusCode,reasonPhase,raw,isSuccess)
        {
        
        }

        public class Success: ListDomainWhitelistResponse
        {
            internal Success(int statusCode, string reasonPhase, string raw):base(statusCode, reasonPhase, raw,true)
            {
              
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
