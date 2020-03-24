namespace getAddress.Sdk.Api.Responses
{
    public abstract class RevokeTokenResponse : ResponseBase<RevokeTokenResponse.Success, RevokeTokenResponse.Failed>
    {
        protected RevokeTokenResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : RevokeTokenResponse
        {

            public Success(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, true)
            {
                SuccessfulResult = this;
            }

        }

        public class Failed : RevokeTokenResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}
