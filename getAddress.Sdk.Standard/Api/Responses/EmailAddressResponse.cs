
namespace getAddress.Sdk.Api.Responses
{

    public abstract class EmailAddressResponse : ResponseBase<EmailAddressResponse.Success,EmailAddressResponse.Failed>
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
                SuccessfulResult = this;
            }
        }

         public class FailedInvalidEmailAddress : EmailAddressResponse
        {
            public string Message { get; set; }

            internal FailedInvalidEmailAddress(int statusCode, string reasonPhase, string raw,string message) : base(statusCode, reasonPhase, raw, false)
            {
                Message = message;
            }
        }

        public class Failed : EmailAddressResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}
