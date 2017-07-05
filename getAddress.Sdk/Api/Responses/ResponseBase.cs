namespace getAddress.Sdk.Api.Responses
{
    public abstract class ResponseBase
    {

        protected ResponseBase(int statusCode, string reasonPhase, string raw, bool isSuccess)
        {
            StatusCode = statusCode;
            ReasonPhase = reasonPhase;
            Raw = raw;
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; }
        public int StatusCode { get; }
        public string ReasonPhase { get; }

        public string Raw { get; }

    }
}
