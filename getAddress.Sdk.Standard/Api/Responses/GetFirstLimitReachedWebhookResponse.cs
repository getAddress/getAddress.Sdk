namespace getAddress.Sdk.Api.Responses
{
    public abstract class GetFirstLimitReachedWebhookResponse : ResponseBase<GetFirstLimitReachedWebhookResponse.Success,
        GetFirstLimitReachedWebhookResponse.Failed, GetFirstLimitReachedWebhookResponse.TokenExpired>
    {

        protected GetFirstLimitReachedWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : GetFirstLimitReachedWebhookResponse
        {
            public FirstLimitReachedWebhook FirstLimitReachedWebhook { get; }

            public Success(int statusCode, string reasonPhrase, string raw, int id, string url) : base(statusCode, reasonPhrase, raw, true)
            {
                FirstLimitReachedWebhook = new FirstLimitReachedWebhook {
                     Id= id,
                     Url = url
                };
                SuccessfulResult = this;
            }
        }


        public class Failed : GetFirstLimitReachedWebhookResponse
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
