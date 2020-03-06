

namespace getAddress.Sdk.Api.Responses
{
    public class RemovePrivateAddressResponse: ResponseBase<RemovePrivateAddressResponse.Success,RemovePrivateAddressResponse.Failed>
    {

        protected RemovePrivateAddressResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess):base(statusCode,reasonPhrase,raw,isSuccess)
        {
        }

        public class Success : RemovePrivateAddressResponse
        {

            internal Success(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, true)
            {
                SuccessfulResult = this;
            }
        }

        public class Failed : RemovePrivateAddressResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                   FailedResult = this;
            }
        }

    }
}
