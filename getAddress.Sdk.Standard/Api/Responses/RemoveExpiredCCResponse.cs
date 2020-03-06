namespace getAddress.Sdk.Api.Responses
{
    public abstract class RemoveExpiredCCResponse : ResponseBase<RemoveExpiredCCResponse.Success, RemoveExpiredCCResponse.Failed>
    {
        protected RemoveExpiredCCResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : RemoveExpiredCCResponse
        {
            public string Message { get; set; }

            public Success(int statusCode, string reasonPhrase, string raw, string message) : base(statusCode, reasonPhrase, raw, true)
            {
                Message = message;
                SuccessfulResult = this;
            }
        }

        public class Failed : RemoveExpiredCCResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}