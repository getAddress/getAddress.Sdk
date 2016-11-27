

namespace getAddress.Sdk.Api.Responses
{
    public abstract class RemoveDomainWhitelistResponse : DomainWhitelistResponse
    {

        protected RemoveDomainWhitelistResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }


        public class Success : AddDomainWhitelistResponse
        {
            internal Success(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, true)
            {

            }
        }

        public class Failed : AddDomainWhitelistResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {

            }
        }
    }
}