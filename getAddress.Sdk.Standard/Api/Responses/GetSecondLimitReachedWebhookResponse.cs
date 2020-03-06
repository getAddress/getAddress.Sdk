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

            public Success(int statusCode, string reasonPhrase, string raw,  SecondLimitReachedWebhook secondLimitReachedWebhook) : base(statusCode, reasonPhrase, raw, true)
            {
                SecondLimitReachedWebhook = secondLimitReachedWebhook;
                SuccessfulResult = this;
            }
            public Success(int statusCode, string reasonPhrase, string raw, int id, string url) : this(statusCode, reasonPhrase, raw, new SecondLimitReachedWebhook
            {
                Id = id,
                Url = url
            })
            {
               
                
            }
        }


        public class Failed : GetSecondLimitReachedWebhookResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}
