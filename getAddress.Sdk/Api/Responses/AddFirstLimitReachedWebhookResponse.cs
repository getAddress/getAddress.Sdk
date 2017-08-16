namespace getAddress.Sdk.Api.Responses
{

    public abstract class AddFirstLimitReachedWebhookResponse : ResponseBase
    {

        protected AddFirstLimitReachedWebhookResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        public class Success : AddFirstLimitReachedWebhookResponse
        {
            public int Id { get; set; }

            public string Message { get; set; }


            internal Success(int statusCode, string reasonPhase, string raw,  string message,string id) : base(statusCode, reasonPhase, raw, true)
            {
                Id = ToInt(id);

                Message = message;
            }
        }


        public class Failed : AddFirstLimitReachedWebhookResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {

            }
        }

        private int ToInt(string id) {

            if(id == null) return 0;

            return int.Parse(id);
        }
    }
}
