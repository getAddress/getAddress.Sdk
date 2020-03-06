namespace getAddress.Sdk.Api.Responses
{
    public abstract class RemoveFirstLimitReachedWebhookResponse : ResponseBase<RemoveFirstLimitReachedWebhookResponse.Success,RemoveFirstLimitReachedWebhookResponse.Failed>
    {

        protected RemoveFirstLimitReachedWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : RemoveFirstLimitReachedWebhookResponse
        {
            public string Message { get; set; }

            internal Success(int statusCode, string reasonPhrase, string raw,  string message) : base(statusCode, reasonPhrase, raw, true)
            {

                SuccessfulResult = this;
                Message = message;
            }
        }


        public class Failed : RemoveFirstLimitReachedWebhookResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                   FailedResult = this;
            }
        }

      
    }
}
