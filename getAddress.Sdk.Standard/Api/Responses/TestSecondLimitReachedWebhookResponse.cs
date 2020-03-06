namespace getAddress.Sdk.Api.Responses
{
    public abstract class TestSecondLimitReachedWebhookResponse : ResponseBase<TestSecondLimitReachedWebhookResponse.Success, TestSecondLimitReachedWebhookResponse.Failed>
    {

        protected TestSecondLimitReachedWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : TestSecondLimitReachedWebhookResponse
        {

            public string Message { get; set; }

            public Success(int statusCode, string reasonPhrase, string raw, string message, string id) : base(statusCode, reasonPhrase, raw, true)
            {
                SuccessfulResult = this;
                Message = message;
            }
        }

        public class Failed : TestSecondLimitReachedWebhookResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                FailedResult = this;
            }
        }


    }

}
