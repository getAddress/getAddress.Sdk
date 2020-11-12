namespace getAddress.Sdk.Api.Responses
{
    public abstract class EmailAddressResponse : ResponseBase<
        EmailAddressResponse.Success,
        EmailAddressResponse.Failed, 
        EmailAddressResponse.TokenExpired,
        EmailAddressResponse.RateLimitedReached,
        EmailAddressResponse.Forbidden>
    {
        internal EmailAddressResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {
        }

        public bool IsFailedAccountAlreayExists { get; private set; }

        public class Success : EmailAddressResponse
        {
            public string EmailAddress { get; }

            public Success(int statusCode, string reasonPhrase, string raw, string emailAddress) : base(statusCode, reasonPhrase, raw, true)
            {
                EmailAddress = emailAddress;
                SuccessfulResult = this;
            }
        }

        public class Failed : EmailAddressResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                   FailedResult = this;
            }

            internal static Failed NewFailed(int statusCode, string reasonPhrase, string raw)
            {
                return new Failed(statusCode, reasonPhrase, raw);
            }
        }

        public class FailedInvalidEmailAddress : Failed
        {
            public string Message { get; set; }

            public FailedInvalidEmailAddress(int statusCode, string reasonPhrase, string raw, string message) : base(statusCode, reasonPhrase, raw)
            {
                Message = message;
            }
        }

        public FailedAccountAlreadyExists FailedAccountAlreadyResult { get; protected set; }

        public class FailedAccountAlreadyExists : Failed
        {
            public FailedAccountAlreadyExists(string reasonPhrase, string raw) : base(409, reasonPhrase, raw)
            {
                FailedAccountAlreadyResult = this;
                IsFailedAccountAlreayExists = true;
            }
        }

        public bool TryGetFailedAccountAlreadyExists(out FailedAccountAlreadyExists failedAccountAlreadyExists)
        {
            if (IsFailedAccountAlreayExists)
            {
                failedAccountAlreadyExists = FailedAccountAlreadyResult;
                return true;
            }

            failedAccountAlreadyExists = default;
            return false;
        }


        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                TokenExpiredResult = this;
                IsTokenExpired = true;
            }

            internal static TokenExpired NewTokenExpired(string reasonPhrase, string raw)
            {
                return new TokenExpired(reasonPhrase, raw);
            }
        }

        public class RateLimitedReached : Failed
        {
            public double RetryAfterSeconds { get; }
            public RateLimitedReached(string reasonPhrase, string raw, double retryAfterSeconds) : base(429, reasonPhrase, raw)
            {
                RetryAfterSeconds = retryAfterSeconds;
                RateLimitReachedResult = this;
                IsRateLimitReached = true;
            }
            internal static RateLimitedReached NewRateLimitedReached(string reasonPhrase, string raw, double retryAfterSeconds)
            {
                return new RateLimitedReached(reasonPhrase, raw, retryAfterSeconds);
            }
        }

        public class Forbidden : Failed
        {
            public Forbidden(string reasonPhrase, string raw) : base(403, reasonPhrase, raw)
            {
                ForbiddenResult = this;
                IsForbidden = true;
            }
        }
    }


}
