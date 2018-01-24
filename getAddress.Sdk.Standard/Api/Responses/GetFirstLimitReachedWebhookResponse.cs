namespace getAddress.Sdk.Api.Responses
{

    public class FirstLimitReachedWebhook
    {
        public int Id { get; set; }

        public string Url { get; set; }
    }


    public abstract class GetFirstLimitReachedWebhookResponse : ResponseBase<GetFirstLimitReachedWebhookResponse.Success,GetFirstLimitReachedWebhookResponse.Failed>
    {

        protected GetFirstLimitReachedWebhookResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        public class Success : GetFirstLimitReachedWebhookResponse
        {
            public FirstLimitReachedWebhook FirstLimitReachedWebhook { get; }

            internal Success(int statusCode, string reasonPhase, string raw, int id, string url) : base(statusCode, reasonPhase, raw, true)
            {
                FirstLimitReachedWebhook = new FirstLimitReachedWebhook {
                     Id= id,
                     Url = url
                };
                SuccessfulResult = this;
            }
        }


        public class Failed : GetFirstLimitReachedWebhookResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}
