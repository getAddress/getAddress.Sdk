namespace getAddress.Sdk.Api.Responses
{
    public abstract class GetFirstLimitReachedWebhookResponse : ResponseBase<GetFirstLimitReachedWebhookResponse.Success,GetFirstLimitReachedWebhookResponse.Failed>
    {

        protected GetFirstLimitReachedWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : GetFirstLimitReachedWebhookResponse
        {
            public FirstLimitReachedWebhook FirstLimitReachedWebhook { get; }

            internal Success(int statusCode, string reasonPhrase, string raw, int id, string url) : base(statusCode, reasonPhrase, raw, true)
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
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}
