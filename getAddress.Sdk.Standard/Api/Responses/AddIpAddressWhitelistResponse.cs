

namespace getAddress.Sdk.Api.Responses
{
    public abstract class AddIpAddressWhitelistResponse: ResponseBase<AddIpAddressWhitelistResponse.Success,AddIpAddressWhitelistResponse.Failed>
    {

        protected AddIpAddressWhitelistResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess):base(statusCode,reasonPhrase,raw,isSuccess)
        {
        }


        public class Success : AddIpAddressWhitelistResponse
        {
            public string Message { get; }

            public string Id { get; }

            public Success(int statusCode, string reasonPhrase, string raw, string message, string id):base(statusCode, reasonPhrase, raw,true)
            {
                Message = message;
                Id = id;
                SuccessfulResult = this;
            }
        }

        public class Failed : AddIpAddressWhitelistResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) :base(statusCode, reasonPhrase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}
