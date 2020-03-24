namespace getAddress.Sdk.Api.Responses
{
    public abstract class AddSecondLimitReachedWebhookResponse : ResponseBase<AddSecondLimitReachedWebhookResponse.Success, 
        AddSecondLimitReachedWebhookResponse.Failed,AddSecondLimitReachedWebhookResponse.TokenExpired>
    {
        protected AddSecondLimitReachedWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : AddSecondLimitReachedWebhookResponse
        {
            public int Id { get; set; }

            public string Message { get; set; }

            public Success(int statusCode, string reasonPhrase, string raw, string message, string id) : base(statusCode, reasonPhrase, raw, true)
            {
                Id = ToInt(id);
                SuccessfulResult = this;
                Message = message;
            }
        }

        public class Failed : AddSecondLimitReachedWebhookResponse
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
                FailedResult = this;
                TokenExpiredResult = this;
            }
        }

        private int ToInt(string id)
        {
            if (id == null) return 0;

            return int.Parse(id);
        }
    }
}
