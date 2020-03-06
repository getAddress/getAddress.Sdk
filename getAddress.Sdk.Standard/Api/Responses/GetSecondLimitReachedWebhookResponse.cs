namespace getAddress.Sdk.Api.Responses
{
    public abstract class GetSecondLimitReachedWebhookResponse : ResponseBase<GetSecondLimitReachedWebhookResponse.Success, GetSecondLimitReachedWebhookResponse.Failed>
    {

        protected GetSecondLimitReachedWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : GetSecondLimitReachedWebhookResponse
        {
            public SecondLimitReachedWebhook SecondLimitReachedWebhook { get; }

            internal Success(int statusCode, string reasonPhrase, string raw, int id, string url) : base(statusCode, reasonPhrase, raw, true)
            {
                SecondLimitReachedWebhook = new SecondLimitReachedWebhook
                {
                    Id = id,
                    Url = url
                };
                SuccessfulResult = this;
            }
        }


        public class Failed : GetSecondLimitReachedWebhookResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}
