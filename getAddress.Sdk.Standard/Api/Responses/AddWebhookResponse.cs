namespace getAddress.Sdk.Api.Responses
{
    public abstract class AddWebhookResponse : ResponseBase<AddWebhookResponse.Success, AddWebhookResponse.Failed>
    {

        protected AddWebhookResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        internal AddFirstLimitReachedWebhookResponse FormerResult()
        {
            if (IsSuccess)
            {
                return new AddFirstLimitReachedWebhookResponse.Success(this.SuccessfulResult.StatusCode, SuccessfulResult.ReasonPhase,
                    SuccessfulResult.Raw, SuccessfulResult.Message, SuccessfulResult.Id.ToString());
            }

            return new AddFirstLimitReachedWebhookResponse.Failed(this.FailedResult.StatusCode, FailedResult.ReasonPhase,
                    FailedResult.Raw);
        }

        internal AddSecondLimitReachedWebhookResponse FormerResult2()
        {
            if (IsSuccess)
            {
                return new AddSecondLimitReachedWebhookResponse.Success(this.SuccessfulResult.StatusCode, SuccessfulResult.ReasonPhase,
                    SuccessfulResult.Raw, SuccessfulResult.Message, SuccessfulResult.Id.ToString());
            }

            return new AddSecondLimitReachedWebhookResponse.Failed(this.FailedResult.StatusCode, FailedResult.ReasonPhase,
                    FailedResult.Raw);
        }

        public class Success : AddWebhookResponse
        {
            public int Id { get; set; }

            public string Message { get; set; }

            internal Success(int statusCode, string reasonPhase, string raw, string message, int id) : base(statusCode, reasonPhase, raw, true)
            {
                Id = id;
                SuccessfulResult = this;
                Message = message;
            }
        }

        public class Failed : AddWebhookResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }

        private int ToInt(string id)
        {

            if (id == null) return 0;

            return int.Parse(id);
        }
    }

}
