namespace getAddress.Sdk.Api.Responses
{
    public abstract class RemoveWebhookResponse : ResponseBase<RemoveWebhookResponse.Success, RemoveWebhookResponse.Failed>
    {

        protected RemoveWebhookResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        public class Success : RemoveWebhookResponse
        {
            public string Message { get; set; }

            internal Success(int statusCode, string reasonPhase, string raw, string message) : base(statusCode, reasonPhase, raw, true)
            {

                SuccessfulResult = this;
                Message = message;
            }
        }

        internal RemoveFirstLimitReachedWebhookResponse FormerResult()
        {
            if (this.IsSuccess)
            {
                return new RemoveFirstLimitReachedWebhookResponse.Success(SuccessfulResult.StatusCode,
                    SuccessfulResult.ReasonPhase, SuccessfulResult.Raw, this.SuccessfulResult.Message);
            }
            else
            {
                return new RemoveFirstLimitReachedWebhookResponse.Failed(SuccessfulResult.StatusCode,
                    SuccessfulResult.ReasonPhase, SuccessfulResult.Raw);
            }
        }

        internal RemoveSecondLimitReachedWebhookResponse FormerResult2()
        {
            if (this.IsSuccess)
            {
                return new RemoveSecondLimitReachedWebhookResponse.Success(SuccessfulResult.StatusCode,
                    SuccessfulResult.ReasonPhase, SuccessfulResult.Raw, this.SuccessfulResult.Message);
            }
            else
            {
                return new RemoveSecondLimitReachedWebhookResponse.Failed(FailedResult.StatusCode,
                    FailedResult.ReasonPhase, FailedResult.Raw);
            }

        }

        public class Failed : RemoveWebhookResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }

    }

}
