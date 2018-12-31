namespace getAddress.Sdk.Api.Responses
{
    public abstract class GetSecondLimitReachedWebhookResponse : ResponseBase<GetSecondLimitReachedWebhookResponse.Success, GetSecondLimitReachedWebhookResponse.Failed>
    {

        protected GetSecondLimitReachedWebhookResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        public class Success : GetSecondLimitReachedWebhookResponse
        {
            public SecondLimitReachedWebhook SecondLimitReachedWebhook { get; }

            internal Success(int statusCode, string reasonPhase, string raw, int id, string url) : base(statusCode, reasonPhase, raw, true)
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
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}
