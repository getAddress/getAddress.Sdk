namespace getAddress.Sdk.Api.Responses
{
    public abstract class TestFirstLimitReachedWebhookResponse : ResponseBase<TestFirstLimitReachedWebhookResponse.Success, TestFirstLimitReachedWebhookResponse.Failed>
    {

        protected TestFirstLimitReachedWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : TestFirstLimitReachedWebhookResponse
        {

            public string Message { get; set; }

            internal Success(int statusCode, string reasonPhrase, string raw, string message, string id) : base(statusCode, reasonPhrase, raw, true)
            {
                SuccessfulResult = this;
                Message = message;
            }
        }

        public class Failed : TestFirstLimitReachedWebhookResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                FailedResult = this;
            }
        }

      
    }

}
