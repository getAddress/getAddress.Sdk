namespace getAddress.Sdk.Api.Responses
{
    public abstract class AddExpiredCCResponse : ResponseBase<AddExpiredCCResponse.Success, AddExpiredCCResponse.Failed>
    {
        protected AddExpiredCCResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {
        }

        public class Success : AddExpiredCCResponse
        {
            public string Message { get; }

            public long Id { get; }

            internal Success(int statusCode, string reasonPhase, string raw, string message, long id) : base(statusCode, reasonPhase, raw, true)
            {
                Message = message;
                Id = id;
                SuccessfulResult = this;
            }
        }

        public class Failed : AddExpiredCCResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}
