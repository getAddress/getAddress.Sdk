namespace getAddress.Sdk.Api.Responses
{
    public abstract class TestFirstLimitReachedWebhookResponse : ResponseBase<TestFirstLimitReachedWebhookResponse.Success, TestFirstLimitReachedWebhookResponse.Failed>
    {

        protected TestFirstLimitReachedWebhookResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        public class Success : TestFirstLimitReachedWebhookResponse
        {

            public string Message { get; set; }

            internal Success(int statusCode, string reasonPhase, string raw, string message, string id) : base(statusCode, reasonPhase, raw, true)
            {
                SuccessfulResult = this;
                Message = message;
            }
        }

        public class Failed : TestFirstLimitReachedWebhookResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }

      
    }

}
