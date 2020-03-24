namespace getAddress.Sdk.Api.Responses
{
    public abstract class RemoveSecondLimitReachedWebhookResponse : ResponseBase<RemoveSecondLimitReachedWebhookResponse.Success,
        RemoveSecondLimitReachedWebhookResponse.Failed, RemoveSecondLimitReachedWebhookResponse.TokenExpired>
    {
        protected RemoveSecondLimitReachedWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : RemoveSecondLimitReachedWebhookResponse
        {
            public string Message { get; set; }

            public Success(int statusCode, string reasonPhrase, string raw,  string message) : base(statusCode, reasonPhrase, raw, true)
            {
                SuccessfulResult = this;
                Message = message;
            }
        }

        public class Failed : RemoveSecondLimitReachedWebhookResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                FailedResult = this;
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
