namespace getAddress.Sdk.Api.Responses
{
    public abstract class RemoveSecondLimitReachedWebhookResponse : ResponseBase<RemoveSecondLimitReachedWebhookResponse.Success,RemoveSecondLimitReachedWebhookResponse.Failed>
    {
        protected RemoveSecondLimitReachedWebhookResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        public class Success : RemoveSecondLimitReachedWebhookResponse
        {
            public string Message { get; set; }


            internal Success(int statusCode, string reasonPhase, string raw,  string message) : base(statusCode, reasonPhase, raw, true)
            {
                SuccessfulResult = this;
                Message = message;
            }
        }


        public class Failed : RemoveSecondLimitReachedWebhookResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                   FailedResult = this;
            }
        }

      
    }
}
