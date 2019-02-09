namespace getAddress.Sdk.Api.Responses
{
    public abstract class TestSecondLimitReachedWebhookResponse : ResponseBase<TestSecondLimitReachedWebhookResponse.Success, TestSecondLimitReachedWebhookResponse.Failed>
    {

        protected TestSecondLimitReachedWebhookResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        public class Success : TestSecondLimitReachedWebhookResponse
        {

            public string Message { get; set; }

            internal Success(int statusCode, string reasonPhase, string raw, string message, string id) : base(statusCode, reasonPhase, raw, true)
            {
                SuccessfulResult = this;
                Message = message;
            }
        }

        public class Failed : TestSecondLimitReachedWebhookResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }


    }

}
