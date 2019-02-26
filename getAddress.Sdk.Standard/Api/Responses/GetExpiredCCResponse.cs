

namespace getAddress.Sdk.Api.Responses
{
    public class GetExpiredCCResponse : ResponseBase<GetExpiredCCResponse.Success, GetExpiredCCResponse.Failed>
    {

        protected GetExpiredCCResponse(int statusCode, string reasonPhase, string raw, bool isSuccess)
            : base(statusCode, reasonPhase, raw, isSuccess)
        {


        }

        public class Success : GetExpiredCCResponse
        {
            public ExpiredCC ExpiredCC { get; }


            internal Success(int statusCode, string reasonPhase, string raw, ExpiredCC expiredCC) : base(statusCode, reasonPhase, raw, true)
            {
                ExpiredCC = expiredCC;
                this.SuccessfulResult = this;
            }
        }

        public class Failed : GetExpiredCCResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                this.FailedResult = this;
            }
        }
    }
}

