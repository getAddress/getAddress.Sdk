using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class RemovePermissionResponse : ResponseBase<RemovePermissionResponse.Success,
        RemovePermissionResponse.Failed, 
        RemovePermissionResponse.TokenExpired,
        RemovePermissionResponse.RateLimitedReached>
    {
        internal RemovePermissionResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {
        }

        public class Success : RemovePermissionResponse
        {
            public string Message { get; }

            public Success(int statusCode, string reasonPhrase, string raw, string message) : base(statusCode, reasonPhrase, raw, true)
            {
                SuccessfulResult = this;
                Message = message;
            }
        }

        public class Failed : RemovePermissionResponse
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

            internal static TokenExpired NewTokenExpired(string reasonPhrase, string raw)
            {
                return new TokenExpired(reasonPhrase, raw);
            }
        }

        public class RateLimitedReached : Failed
        {
            public int RetryAfterSeconds { get; }
            public RateLimitedReached(string reasonPhrase, string raw, int retryAfterSeconds) : base(429, reasonPhrase, raw)
            {
                RetryAfterSeconds = retryAfterSeconds;
                RateLimitReachedResult = this;
                IsRateLimitReached = true;
            }
            internal static RateLimitedReached NewRateLimitedReached(string reasonPhrase, string raw, int retryAfterSeconds)
            {
                return new RateLimitedReached(reasonPhrase, raw, retryAfterSeconds);
            }
        }
    }

    public class AddPermissionResponse : ResponseBase<
        AddPermissionResponse.Success, 
        AddPermissionResponse.Failed, 
        AddPermissionResponse.TokenExpired,
        AddPermissionResponse.RateLimitedReached>
    {
        internal AddPermissionResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {
        }

        public class Success : AddPermissionResponse
        {
            public string Message { get; }

            internal Success(int statusCode, string reasonPhrase, string raw, string message) : base(statusCode, reasonPhrase, raw, true)
            {
                SuccessfulResult = this;
                Message = message;
            }
        }


        public class Failed : AddPermissionResponse
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
            public int RetryAfterSeconds { get; }
            public RateLimitedReached(string reasonPhrase, string raw, int retryAfterSeconds) : base(429, reasonPhrase, raw)
            {
                RetryAfterSeconds = retryAfterSeconds;
                RateLimitReachedResult = this;
                IsRateLimitReached = true;
            }
            internal static RateLimitedReached NewRateLimitedReached(string reasonPhrase, string raw, int retryAfterSeconds)
            {
                return new RateLimitedReached(reasonPhrase, raw, retryAfterSeconds);
            }
        }
    }

    public class UpdatePermissionResponse : ResponseBase<
        UpdatePermissionResponse.Success, 
        UpdatePermissionResponse.Failed, 
        UpdatePermissionResponse.TokenExpired,
        UpdatePermissionResponse.RateLimitedReached>
    {
        internal UpdatePermissionResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {
        }

        public class Success : UpdatePermissionResponse
        {
            public string Message { get; }

            internal Success(int statusCode, string reasonPhrase, string raw, string message) : base(statusCode, reasonPhrase, raw, true)
            {
                SuccessfulResult = this;
                Message = message;
            }
        }


        public class Failed : UpdatePermissionResponse
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
            public int RetryAfterSeconds { get; }
            public RateLimitedReached(string reasonPhrase, string raw, int retryAfterSeconds) : base(429, reasonPhrase, raw)
            {
                RetryAfterSeconds = retryAfterSeconds;
                RateLimitReachedResult = this;
                IsRateLimitReached = true;
            }
            internal static RateLimitedReached NewRateLimitedReached(string reasonPhrase, string raw, int retryAfterSeconds)
            {
                return new RateLimitedReached(reasonPhrase, raw, retryAfterSeconds);
            }
        }
    }

    public class ListPermissionResponse : ResponseBase<
        ListPermissionResponse.Success, 
        ListPermissionResponse.Failed, 
        ListPermissionResponse.TokenExpired,
        ListPermissionResponse.RateLimitedReached>
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
            public int RetryAfterSeconds { get; }
            public RateLimitedReached(string reasonPhrase, string raw, int retryAfterSeconds) : base(429, reasonPhrase, raw)
            {
                RetryAfterSeconds = retryAfterSeconds;
                RateLimitReachedResult = this;
                IsRateLimitReached = true;
            }
            internal static RateLimitedReached NewRateLimitedReached(string reasonPhrase, string raw, int retryAfterSeconds)
            {
                return new RateLimitedReached(reasonPhrase, raw, retryAfterSeconds);
            }
        }
    }

    public class PermissionResponse : ResponseBase<
        PermissionResponse.Success, 
        PermissionResponse.Failed, 
        PermissionResponse.TokenExpired,
        PermissionResponse.RateLimitedReached>
    {
        internal PermissionResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {
        }

        public class Success : PermissionResponse
        {
            public Permission Permission { get; }

            internal Success(int statusCode, string reasonPhrase, string raw, Permission permission) : base(statusCode, reasonPhrase, raw, true)
            {
                Permission = permission;
                SuccessfulResult = this;
            }
        }


        public class Failed : PermissionResponse
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
            public int RetryAfterSeconds { get; }
            public RateLimitedReached(string reasonPhrase, string raw, int retryAfterSeconds) : base(429, reasonPhrase, raw)
            {
                RetryAfterSeconds = retryAfterSeconds;
                RateLimitReachedResult = this;
                IsRateLimitReached = true;
            }
            internal static RateLimitedReached NewRateLimitedReached(string reasonPhrase, string raw, int retryAfterSeconds)
            {
                return new RateLimitedReached(reasonPhrase, raw, retryAfterSeconds);
            }
        }
    }

    public class Permissions
    {
        [JsonProperty("view_invoices")]
        public bool ViewInvoices { get; set; }

        [JsonProperty("unsubscribe")]
        public bool Unsubscribe { get; set; }

        [JsonProperty("update_card_details")]
        public bool UpdateCardDetails { get; set; }
    }

    public class Permission
    {
        [JsonProperty("expires")]
        public DateTime Expires { get; set; }

        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty("permissions")]
        public Permissions Permissions { get; set; }


    }

}
