
namespace getAddress.Sdk.Api.Responses
{
    public abstract class DistanceResponse : ResponseBase<DistanceResponse.Success, DistanceResponse.Failed>
    {
        internal DistanceResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {
        }


        public class Success : DistanceResponse
        {
            public Distance Distance { get; }

            internal Success(int statusCode, string reasonPhrase, string raw, Distance distance) : base(statusCode, reasonPhrase, raw, true)
            {
                Distance = distance;
                SuccessfulResult = this;
            }
        }


        public class Failed : DistanceResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                FailedResult = this;
            }
        }
    }


}
