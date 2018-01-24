namespace getAddress.Sdk.Api.Responses
{
    public abstract class UnsubscribeResponse: ResponseBase<UnsubscribeResponse.Success,UnsubscribeResponse.Failed>
    {
        protected UnsubscribeResponse(int statusCode, string reasonPhase, string raw, bool isSuccess):base(statusCode,reasonPhase,raw,isSuccess)
        {
        }


        public class Success : UnsubscribeResponse
        {
          

            internal Success(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, true)
            {
                SuccessfulResult = this;
            }
        }

        public class Failed : UnsubscribeResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}
