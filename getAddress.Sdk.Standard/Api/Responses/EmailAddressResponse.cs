﻿
namespace getAddress.Sdk.Api.Responses
{

    public abstract class EmailAddressResponse : ResponseBase
    {
        internal EmailAddressResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {
        }


        public class Success : EmailAddressResponse
        {
            public string EmailAddress { get; }

            internal Success(int statusCode, string reasonPhase, string raw, string emailAddress) : base(statusCode, reasonPhase, raw, true)
            {
                EmailAddress = emailAddress;
            }
        }


        public class Failed : EmailAddressResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {

            }
        }
    }
}
