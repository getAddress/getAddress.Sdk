

namespace getAddress.Sdk.Api.Responses
{
    public abstract class RemoveIpAddressWhitelistResponse : ResponseBase<RemoveIpAddressWhitelistResponse.Success,RemoveIpAddressWhitelistResponse.Failed>
    {

        protected RemoveIpAddressWhitelistResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }


        public class Success : RemoveIpAddressWhitelistResponse
        {
            public string Message { get; set; }

            internal Success(int statusCode, string reasonPhase, string raw, string message) : base(statusCode, reasonPhase, raw, true)
            {
                Message = message;
                SuccessfulResult = this;
            }
        }

        public class Failed : RemoveIpAddressWhitelistResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}