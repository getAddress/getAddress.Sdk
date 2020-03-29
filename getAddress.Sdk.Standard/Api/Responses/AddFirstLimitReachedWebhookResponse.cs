namespace getAddress.Sdk.Api.Responses
{
    public abstract class AddFirstLimitReachedWebhookResponse : ResponseBase<AddFirstLimitReachedWebhookResponse.Success,
        AddFirstLimitReachedWebhookResponse.Failed, AddFirstLimitReachedWebhookResponse.TokenExpired>
    {

        protected AddFirstLimitReachedWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : AddFirstLimitReachedWebhookResponse
        {
            public int Id { get; set; }

            public string Message { get; set; }

            public Success(int statusCode, string reasonPhrase, string raw,  string message,string id) : base(statusCode, reasonPhrase, raw, true)
            {
                Id = ToInt(id);
                SuccessfulResult = this;
                Message = message;
            }
        }

        public class Failed : AddFirstLimitReachedWebhookResponse
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

        private int ToInt(string id) {

            if(id == null) return 0;

            return int.Parse(id);
        }
    }

}
