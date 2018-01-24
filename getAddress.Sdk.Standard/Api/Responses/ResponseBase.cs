namespace getAddress.Sdk.Api.Responses
{
    public abstract class ResponseBase<S,F>
    {

        protected ResponseBase(int statusCode, string reasonPhase, string raw, bool isSuccess)
        {
            StatusCode = statusCode;
            ReasonPhase = reasonPhase;
            Raw = raw;
            IsSuccess = isSuccess;
        }

        public S SuccessfulResult{ get; protected set; }
        public F  FailedResult{ get; protected set; }

        public bool IsSuccess { get; }
        public int StatusCode { get; }
        public string ReasonPhase { get; }

        public string Raw { get; }

    }
}
