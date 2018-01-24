
namespace getAddress.Sdk.Api.Responses
{


    public abstract class ApiKeyResponse : ResponseBase<ApiKeyResponse.Success,ApiKeyResponse.Failed>
    {
        internal ApiKeyResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {
        }


        public class Success : ApiKeyResponse
        {
            public string ApiKey { get; }

            internal Success(int statusCode, string reasonPhase, string raw, string apiKey) : base(statusCode, reasonPhase, raw, true)
            {
                ApiKey = apiKey;
                SuccessfulResult = this;
            }
        }


        public class Failed : ApiKeyResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}
