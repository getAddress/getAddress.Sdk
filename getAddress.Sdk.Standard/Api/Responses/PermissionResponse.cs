﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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

    public class ListPermissionResponse : ResponseBase<ListPermissionResponse.Success, ListPermissionResponse.Failed>
    {
        internal ListPermissionResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {
        }

        public class Success : ListPermissionResponse
        {
            public IEnumerable<Permission> Permissions { get; }

            internal Success(int statusCode, string reasonPhase, string raw, IEnumerable<Permission> permissions) : base(statusCode, reasonPhase, raw, true)
            {
                SuccessfulResult = this;
                Permissions = permissions;
            }
        }

        public class Failed : ListPermissionResponse
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
            public Permission Permission { get; }

            internal Success(int statusCode, string reasonPhase, string raw, Permission permission) : base(statusCode, reasonPhase, raw, true)
            {
                Permission = permission;
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