using System;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ResponseBase<S, F, X,R,FO>
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
        public R RateLimitReachedResult { get; protected set; }

        public FO ForbiddenResult { get; protected set; }

        public bool IsForbidden { get; protected set; }

        public bool IsSuccess { get; }

        public bool IsTokenExpired { get; protected set; }

        public bool IsRateLimitReached { get; protected set; }

        public bool TryRateLimitReached(out R rateLimitReachResult)
        {
            if (IsRateLimitReached)
            {
                rateLimitReachResult = RateLimitReachedResult;
                return true;
            }

            rateLimitReachResult = default;
            return false;
        }

        public bool TryGetSuccess(out S successfulResult)
        {
            if (IsSuccess)
            {
                successfulResult = SuccessfulResult;
                return true;
            }

            successfulResult = default;
            return false;
        }

        public bool TryGetTokenExpired(out X tokenExpiredResult)
        {
            if (IsRateLimitReached)
            {
                tokenExpiredResult = TokenExpiredResult;
                return true;
            }

            tokenExpiredResult = default;
            return false;
        }

        public bool TryGetForbidden(out FO forbiddenResult)
        {
            if (IsForbidden)
            {
                forbiddenResult = ForbiddenResult;
                return true;
            }

            forbiddenResult = default;
            return false;
        }

        public int StatusCode { get; }
        
        [Obsolete("Please use ReasonPhrase")]
        public string ReasonPhase { get; }

        public string ReasonPhrase { get; }

        public string Raw { get; }



    }
}
