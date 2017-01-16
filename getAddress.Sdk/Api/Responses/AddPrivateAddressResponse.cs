

namespace getAddress.Sdk.Api.Responses
{
    public class AddPrivateAddressResponse: AdminResponse
    {
        protected AddPrivateAddressResponse(int statusCode, string reasonPhase, string raw, bool isSuccess):base(statusCode,reasonPhase,raw,isSuccess)
        {
        }

        public class Success : AddPrivateAddressResponse
        {
            public string Message { get; }

            public string Id { get; }

            internal Success(int statusCode, string reasonPhase, string raw, string message, string id) : base(statusCode, reasonPhase, raw, true)
            {
            }
        }

        public class Failed : AddPrivateAddressResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {

            }
        }
    }
}
