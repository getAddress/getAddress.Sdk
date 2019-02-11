namespace getAddress.Sdk.Api.Responses
{
    public abstract class GetWebhookResponse : ResponseBase<GetWebhookResponse.Success, GetWebhookResponse.Failed>
    {

        protected GetWebhookResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        internal GetFirstLimitReachedWebhookResponse FormerResult()
        {
            if (this.IsSuccess)
            {
                return new GetFirstLimitReachedWebhookResponse.Success(SuccessfulResult.StatusCode,
                    SuccessfulResult.ReasonPhase, SuccessfulResult.Raw, SuccessfulResult.Webhook.Id,SuccessfulResult.Webhook.Url);
            }

            return new GetFirstLimitReachedWebhookResponse.Failed(FailedResult.StatusCode, FailedResult.ReasonPhase, FailedResult.Raw);
        }

        internal GetSecondLimitReachedWebhookResponse FormerResult2()
        {
            if (this.IsSuccess)
            {
                return new GetSecondLimitReachedWebhookResponse.Success(SuccessfulResult.StatusCode,
                    SuccessfulResult.ReasonPhase, SuccessfulResult.Raw, SuccessfulResult.Webhook.Id, SuccessfulResult.Webhook.Url);
            }

            return new GetSecondLimitReachedWebhookResponse.Failed(FailedResult.StatusCode, FailedResult.ReasonPhase, FailedResult.Raw);
        }

        public class Success : GetWebhookResponse
        {
            public Webhook Webhook { get; }

            internal Success(int statusCode, string reasonPhase, string raw, int id, string url) : base(statusCode, reasonPhase, raw, true)
            {
                Webhook = new Webhook
                {
                    Id = id,
                    Url = url
                };
                SuccessfulResult = this;
            }
        }


        public class Failed : GetWebhookResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}
