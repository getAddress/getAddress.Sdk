

namespace getAddress.Sdk.Api.Responses
{
    public class GetExpiredCCResponse : ResponseBase<GetExpiredCCResponse.Success, GetExpiredCCResponse.Failed>
    {

        protected GetExpiredCCResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess)
            : base(statusCode, reasonPhrase, raw, isSuccess)
        {


        }

        public class Success : GetExpiredCCResponse
        {
            public ExpiredCC ExpiredCC { get; }


            internal Success(int statusCode, string reasonPhrase, string raw, ExpiredCC expiredCC) : base(statusCode, reasonPhrase, raw, true)
            {
                ExpiredCC = expiredCC;
                this.SuccessfulResult = this;
            }
        }

        public class Failed : GetExpiredCCResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                this.FailedResult = this;
            }
        }
    }
}

