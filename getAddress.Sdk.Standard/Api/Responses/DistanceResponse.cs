
namespace getAddress.Sdk.Api.Responses
{
    public abstract class DistanceResponse : ResponseBase<DistanceResponse.Success, DistanceResponse.Failed, DistanceResponse.TokenExpired>
    {
        internal DistanceResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {
        }


        public class Success : DistanceResponse
        {
            public Distance Distance { get; }

            public Success(int statusCode, string reasonPhrase, string raw, Distance distance) : base(statusCode, reasonPhrase, raw, true)
            {
                Distance = distance;
                SuccessfulResult = this;
            }
        }


        public class Failed : DistanceResponse
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
