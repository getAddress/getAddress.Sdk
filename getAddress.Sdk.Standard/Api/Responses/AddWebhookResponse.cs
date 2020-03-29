namespace getAddress.Sdk.Api.Responses
{
    public abstract class AddWebhookResponse : ResponseBase<AddWebhookResponse.Success, AddWebhookResponse.Failed,AddWebhookResponse.TokenExpired>
    {

        protected AddWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public AddFirstLimitReachedWebhookResponse FormerResult()
        {
            if (IsSuccess)
            {
                return new AddFirstLimitReachedWebhookResponse.Success(this.SuccessfulResult.StatusCode, SuccessfulResult.ReasonPhase,
                    SuccessfulResult.Raw, SuccessfulResult.Message, SuccessfulResult.Id.ToString());
            }

            return new AddFirstLimitReachedWebhookResponse.Failed(this.FailedResult.StatusCode, FailedResult.ReasonPhase,
                    FailedResult.Raw);
        }

        public AddSecondLimitReachedWebhookResponse FormerResult2()
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

            public Success(int statusCode, string reasonPhrase, string raw, string message, int id) : base(statusCode, reasonPhrase, raw, true)
            {
                Id = id;
                SuccessfulResult = this;
                Message = message;
            }
        }

        public class Failed : AddWebhookResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                FailedResult = this;
            }
        }

        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                TokenExpiredResult = this;
                IsTokenExpired = true;
            }
        }

        private int ToInt(string id)
        {

            if (id == null) return 0;

            return int.Parse(id);
        }
    }

}
