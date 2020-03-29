using System;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ResponseBase<S, F, X>
    {
        protected ResponseBase(int statusCode, string reasonPhrase, string raw, bool isSuccess)
        {
            StatusCode = statusCode;
            ReasonPhase = reasonPhrase;
            ReasonPhrase = reasonPhrase;
            Raw = raw;
            IsSuccess = isSuccess;
        }

        public S SuccessfulResult { get; protected set; }
        public F FailedResult { get; protected set; }

        public X TokenExpiredResult { get; protected set; }

        public bool IsSuccess { get; }

        public bool IsTokenExpired { get; protected set; }

        public bool TryGetSuccess(out S successfulResult)
        {
            if (IsSuccess)
            {
                successfulResult = SuccessfulResult;
                return true;
            }

            successfulResult = default(S);
            return false;
        }

        public int StatusCode { get; }
        
        [Obsolete("Please use ReasonPhrase")]
        public string ReasonPhase { get; }

        public string ReasonPhrase { get; }

        public string Raw { get; }

    }
}
