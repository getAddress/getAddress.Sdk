namespace getAddress.Sdk.Api.Responses
{
    public abstract class RemoveFirstLimitReachedWebhookResponse : ResponseBase<RemoveFirstLimitReachedWebhookResponse.Success,RemoveFirstLimitReachedWebhookResponse.Failed>
    {

        protected RemoveFirstLimitReachedWebhookResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        public class Success : RemoveFirstLimitReachedWebhookResponse
        {
            public string Message { get; set; }

            internal Success(int statusCode, string reasonPhase, string raw,  string message) : base(statusCode, reasonPhase, raw, true)
            {

                SuccessfulResult = this;
                Message = message;
            }
        }


        public class Failed : RemoveFirstLimitReachedWebhookResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                   FailedResult = this;
            }
        }

      
    }
}
