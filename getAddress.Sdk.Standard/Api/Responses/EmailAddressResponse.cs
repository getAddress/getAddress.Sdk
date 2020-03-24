
namespace getAddress.Sdk.Api.Responses
{
    public abstract class EmailAddressResponse : ResponseBase<EmailAddressResponse.Success,EmailAddressResponse.Failed, EmailAddressResponse.TokenExpired>
    {
        internal EmailAddressResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {
        }


        public class Success : EmailAddressResponse
        {
            public string EmailAddress { get; }

            public Success(int statusCode, string reasonPhrase, string raw, string emailAddress) : base(statusCode, reasonPhrase, raw, true)
            {
                EmailAddress = emailAddress;
                SuccessfulResult = this;
            }
        }

         public class FailedInvalidEmailAddress : EmailAddressResponse
        {
            public string Message { get; set; }

            public FailedInvalidEmailAddress(int statusCode, string reasonPhrase, string raw,string message) : base(statusCode, reasonPhrase, raw, false)
            {
                Message = message;
            }
        }

        public class Failed : EmailAddressResponse
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


}
