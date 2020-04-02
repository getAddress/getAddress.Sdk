using Newtonsoft.Json;
using System;

namespace getAddress.Sdk.Api.Responses
{

    public class PermissionResponse : ResponseBase<
        PermissionResponse.Success, 
        PermissionResponse.Failed, 
        PermissionResponse.TokenExpired,
        PermissionResponse.RateLimitedReached,
        PermissionResponse.Forbidden>
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
