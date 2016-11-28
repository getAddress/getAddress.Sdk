

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListIpAddressWhitelistResponse: AdminResponse
    {

        protected ListIpAddressWhitelistResponse(int statusCode, string reasonPhase, string raw, bool isSuccess):base(statusCode,reasonPhase,raw,isSuccess)
        {
        }

        public class Success: ListIpAddressWhitelistResponse
        {
            internal Success(int statusCode, string reasonPhase, string raw):base(statusCode, reasonPhase, raw,true)
            {
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
