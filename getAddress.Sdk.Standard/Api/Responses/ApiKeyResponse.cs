
namespace getAddress.Sdk.Api.Responses
{

    public abstract class ApiKeyResponse : ResponseBase<ApiKeyResponse.Success,ApiKeyResponse.Failed,ApiKeyResponse.TokenExpired>
    {
        internal ApiKeyResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {
        }


        public class Success : ApiKeyResponse
        {
            public string ApiKey { get; }

            public Success(int statusCode, string reasonPhrase, string raw, string apiKey) : base(statusCode, reasonPhrase, raw, true)
            {
                ApiKey = apiKey;
                SuccessfulResult = this;
            }
        }


        public class Failed : ApiKeyResponse
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
                TokenExpiredResult = this;
                IsTokenExpired = true;
            }
        }
    }
}
