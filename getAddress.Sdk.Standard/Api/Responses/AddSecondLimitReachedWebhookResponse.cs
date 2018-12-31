namespace getAddress.Sdk.Api.Responses
{
    public abstract class AddSecondLimitReachedWebhookResponse : ResponseBase<AddSecondLimitReachedWebhookResponse.Success, AddSecondLimitReachedWebhookResponse.Failed>
    {
        protected AddSecondLimitReachedWebhookResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        public class Success : AddSecondLimitReachedWebhookResponse
        {
            public int Id { get; set; }

            public string Message { get; set; }

            internal Success(int statusCode, string reasonPhase, string raw, string message, string id) : base(statusCode, reasonPhase, raw, true)
            {
                Id = ToInt(id);
                SuccessfulResult = this;
                Message = message;
            }
        }

        public class Failed : AddSecondLimitReachedWebhookResponse
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
