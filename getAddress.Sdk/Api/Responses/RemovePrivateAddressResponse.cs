

namespace getAddress.Sdk.Api.Responses
{
    public class RemovePrivateAddressResponse: ResponseBase
    {

        protected RemovePrivateAddressResponse(int statusCode, string reasonPhase, string raw, bool isSuccess):base(statusCode,reasonPhase,raw,isSuccess)
        {
        }

        public class Success : RemovePrivateAddressResponse
        {

            internal Success(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, true)
            {
            }
        }

        public class Failed : RemovePrivateAddressResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {

            }
        }

    }
}
