

namespace getAddress.Sdk.Api.Responses
{
    public abstract class AddDomainWhitelistResponse: ResponseBase<AddDomainWhitelistResponse.Success,AddDomainWhitelistResponse.Failed>
    {

        protected AddDomainWhitelistResponse(int statusCode, string reasonPhase, string raw, bool isSuccess):base(statusCode,reasonPhase,raw,isSuccess)
        {
        }


        public class Success : AddDomainWhitelistResponse
        {
            public string Message { get; }

            public string Id { get; }

            internal Success(int statusCode, string reasonPhase, string raw, string message, string id):base(statusCode, reasonPhase, raw,true)
            {
                Message = message;
                Id = id;
                SuccessfulResult = this;
            }
        }

        public class Failed : AddDomainWhitelistResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) :base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}
