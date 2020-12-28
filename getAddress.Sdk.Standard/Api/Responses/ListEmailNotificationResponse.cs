using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListEmailNotificationResponse : ResponseBase<
        ListEmailNotificationResponse.Success,
        ListEmailNotificationResponse.Failed,
        ListEmailNotificationResponse.TokenExpired,
        ListEmailNotificationResponse.RateLimitedReached,
        ListEmailNotificationResponse.Forbidden>
    {

        protected ListEmailNotificationResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : ListEmailNotificationResponse
        {
            public IEnumerable<EmailNotification> EmailNotifications { get; }

            public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<EmailNotification> emailNotifications) : base(statusCode, reasonPhrase, raw, true)
            {
                EmailNotifications = emailNotifications;
                SuccessfulResult = this;
            }
        }

        public class Failed : ListEmailNotificationResponse
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

        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                TokenExpiredResult = this;
                IsTokenExpired = true;
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
