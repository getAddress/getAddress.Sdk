

namespace getAddress.Sdk.Api.Responses
{
    public abstract class RemoveIpAddressWhitelistResponse : ResponseBase
    {

        protected RemoveIpAddressWhitelistResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }


        public class Success : RemoveIpAddressWhitelistResponse
        {
            internal Success(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, true)
            {

            }
        }

        public class Failed : RemoveIpAddressWhitelistResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {

            }
        }
    }
}