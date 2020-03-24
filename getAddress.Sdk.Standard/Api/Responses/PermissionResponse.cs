using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class RemovePermissionResponse : ResponseBase<RemovePermissionResponse.Success,
        RemovePermissionResponse.Failed, RemovePermissionResponse.TokenExpired>
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
        }

        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                FailedResult = this;
                TokenExpiredResult = this;
            }
        }
    }

    public class AddPermissionResponse : ResponseBase<AddPermissionResponse.Success, AddPermissionResponse.Failed, AddPermissionResponse.TokenExpired>
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
        }
        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                FailedResult = this;
                TokenExpiredResult = this;
            }
        }
    }

    public class UpdatePermissionResponse : ResponseBase<UpdatePermissionResponse.Success, UpdatePermissionResponse.Failed, UpdatePermissionResponse.TokenExpired>
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
        }

        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                FailedResult = this;
                TokenExpiredResult = this;
            }
        }
    }

    public class ListPermissionResponse : ResponseBase<ListPermissionResponse.Success, ListPermissionResponse.Failed, ListPermissionResponse.TokenExpired>
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
        }

        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                FailedResult = this;
                TokenExpiredResult = this;
            }
        }
    }

    public class PermissionResponse : ResponseBase<PermissionResponse.Success, PermissionResponse.Failed, PermissionResponse.TokenExpired>
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
        }

        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                FailedResult = this;
                TokenExpiredResult = this;
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
