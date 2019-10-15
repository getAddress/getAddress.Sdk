using Newtonsoft.Json;
using System;

namespace getAddress.Sdk.Api.Responses
{
    public class RemovePermissionResponse : ResponseBase<RemovePermissionResponse.Success, RemovePermissionResponse.Failed>
    {
        internal RemovePermissionResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {
        }

        public class Success : RemovePermissionResponse
        {
            public string Message { get; }

            internal Success(int statusCode, string reasonPhase, string raw, string message) : base(statusCode, reasonPhase, raw, true)
            {
                SuccessfulResult = this;
                Message = message;
            }
        }


        public class Failed : RemovePermissionResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }
    }

    public class AddPermissionResponse : ResponseBase<AddPermissionResponse.Success, AddPermissionResponse.Failed>
    {
        internal AddPermissionResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {
        }

        public class Success : AddPermissionResponse
        {
            public string Message { get; }

            internal Success(int statusCode, string reasonPhase, string raw, string message) : base(statusCode, reasonPhase, raw, true)
            {
                SuccessfulResult = this;
                Message = message;
            }
        }


        public class Failed : AddPermissionResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }
    }

    public class UpdatePermissionResponse : ResponseBase<UpdatePermissionResponse.Success, UpdatePermissionResponse.Failed>
    {
        internal UpdatePermissionResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {
        }

        public class Success : UpdatePermissionResponse
        {
            public string Message { get; }

            internal Success(int statusCode, string reasonPhase, string raw, string message) : base(statusCode, reasonPhase, raw, true)
            {
                SuccessfulResult = this;
                Message = message;
            }
        }


        public class Failed : UpdatePermissionResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }
    }

    public class PermissionResponse : ResponseBase<PermissionResponse.Success, PermissionResponse.Failed>
    {
        internal PermissionResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {
        }

        public class Success : PermissionResponse
        {
            public DateTime Expires { get; }

            public Permissions Permissions { get; }

            internal Success(int statusCode, string reasonPhase, string raw, DateTime expires, Permissions permissions) : base(statusCode, reasonPhase, raw, true)
            {
                Expires = expires;
                Permissions = permissions;
                SuccessfulResult = this;
            }
        }


        public class Failed : PermissionResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }
    }

    public class Permissions
    {
        [JsonProperty("view_invoices")]
        public bool ViewInvoices { get; set; }

        [JsonProperty("unsubscribe")]
        public bool Unsubscribe { get; set; }
    }
}
