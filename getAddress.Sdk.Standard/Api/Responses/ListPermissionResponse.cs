﻿using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class ListPermissionResponse : ResponseBase<
        ListPermissionResponse.Success, 
        ListPermissionResponse.Failed, 
        ListPermissionResponse.TokenExpired,
        ListPermissionResponse.RateLimitedReached,
        ListPermissionResponse.Forbidden>
    {
        internal ListPermissionResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {
        }

        public class Success : ListPermissionResponse
        {
            public IEnumerable<Permission> Permissions { get; }

            internal Success(int statusCode, string reasonPhrase, string raw, IEnumerable<Permission> permissions) : base(statusCode, reasonPhrase, raw, true)
            {
                SuccessfulResult = this;
                Permissions = permissions;
            }
        }

        public class Failed : ListPermissionResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
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
