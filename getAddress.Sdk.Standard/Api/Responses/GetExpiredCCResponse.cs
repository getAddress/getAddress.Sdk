

namespace getAddress.Sdk.Api.Responses
{
    public class GetExpiredCCResponse : ResponseBase<GetExpiredCCResponse.Success, 
        GetExpiredCCResponse.Failed,GetExpiredCCResponse.TokenExpired>
    {

        protected GetExpiredCCResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess)
            : base(statusCode, reasonPhrase, raw, isSuccess)
        {


        }

        public class Success : GetExpiredCCResponse
        {
            public ExpiredCC ExpiredCC { get; }


            public Success(int statusCode, string reasonPhrase, string raw, ExpiredCC expiredCC) : base(statusCode, reasonPhrase, raw, true)
            {
                ExpiredCC = expiredCC;
                this.SuccessfulResult = this;
            }
        }

        public class Failed : GetExpiredCCResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                this.FailedResult = this;
            }
        }

        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                FailedResult = this;
                TokenExpiredResult = this;
            }
        }
    }
}

