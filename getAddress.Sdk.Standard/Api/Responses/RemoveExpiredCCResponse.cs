
namespace getAddress.Sdk.Api.Responses
{
    public abstract class RemoveExpiredCCResponse : ResponseBase<RemoveExpiredCCResponse.Success, RemoveExpiredCCResponse.Failed>
    {
        protected RemoveExpiredCCResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        public class Success : RemoveExpiredCCResponse
        {
            public string Message { get; set; }

            internal Success(int statusCode, string reasonPhase, string raw, string message) : base(statusCode, reasonPhase, raw, true)
            {
                Message = message;
                SuccessfulResult = this;
            }
        }

        public class Failed : RemoveExpiredCCResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}