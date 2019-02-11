namespace getAddress.Sdk.Api.Responses
{
    public abstract class TestWebhookResponse : ResponseBase<TestWebhookResponse.Success, TestWebhookResponse.Failed>
    {

        protected TestWebhookResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        public class Success : TestWebhookResponse
        {

            public string Message { get; set; }

            internal Success(int statusCode, string reasonPhase, string raw, string message, string id) : base(statusCode, reasonPhase, raw, true)
            {
                SuccessfulResult = this;
                Message = message;
            }
        }

        public class Failed : TestWebhookResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }


    }

}
