

namespace getAddress.Sdk.Api.Responses
{
    public abstract class AddIpAddressWhitelistResponse: ResponseBase
    {

        protected AddIpAddressWhitelistResponse(int statusCode, string reasonPhase, string raw, bool isSuccess):base(statusCode,reasonPhase,raw,isSuccess)
        {
        }


        public class Success : AddIpAddressWhitelistResponse
        {
            public string Message { get; }

            public string Id { get; }

            internal Success(int statusCode, string reasonPhase, string raw, string message, string id):base(statusCode, reasonPhase, raw,true)
            {
            }
        }

        public class Failed : AddIpAddressWhitelistResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) :base(statusCode, reasonPhase, raw, false)
            {

            }
        }
    }
}
