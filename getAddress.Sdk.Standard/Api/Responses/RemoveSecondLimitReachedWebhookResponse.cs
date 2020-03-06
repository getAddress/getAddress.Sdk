namespace getAddress.Sdk.Api.Responses
{
    public abstract class RemoveSecondLimitReachedWebhookResponse : ResponseBase<RemoveSecondLimitReachedWebhookResponse.Success,RemoveSecondLimitReachedWebhookResponse.Failed>
    {
        protected RemoveSecondLimitReachedWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : RemoveSecondLimitReachedWebhookResponse
        {
            public string Message { get; set; }


            internal Success(int statusCode, string reasonPhrase, string raw,  string message) : base(statusCode, reasonPhrase, raw, true)
            {
                SuccessfulResult = this;
                Message = message;
            }
        }


        public class Failed : RemoveSecondLimitReachedWebhookResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                   FailedResult = this;
            }
        }

      
    }
}
