namespace getAddress.Sdk.Api.Responses
{
    public abstract class UnsubscribeResponse: ResponseBase<UnsubscribeResponse.Success,UnsubscribeResponse.Failed>
    {
        protected UnsubscribeResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess):base(statusCode,reasonPhrase,raw,isSuccess)
        {
        }


        public class Success : UnsubscribeResponse
        {
          

            internal Success(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, true)
            {
                SuccessfulResult = this;
            }
        }

        public class Failed : UnsubscribeResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}
