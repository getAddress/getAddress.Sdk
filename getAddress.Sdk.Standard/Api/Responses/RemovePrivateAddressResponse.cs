

namespace getAddress.Sdk.Api.Responses
{
    public class RemovePrivateAddressResponse: ResponseBase<RemovePrivateAddressResponse.Success,RemovePrivateAddressResponse.Failed>
    {

        protected RemovePrivateAddressResponse(int statusCode, string reasonPhase, string raw, bool isSuccess):base(statusCode,reasonPhase,raw,isSuccess)
        {
        }

        public class Success : RemovePrivateAddressResponse
        {

            internal Success(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, true)
            {
                SuccessfulResult = this;
            }
        }

        public class Failed : RemovePrivateAddressResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                   FailedResult = this;
            }
        }

    }
}
