
namespace getAddress.Sdk.Api.Responses
{
    public abstract class DistanceResponse : ResponseBase<DistanceResponse.Success, DistanceResponse.Failed>
    {
        internal DistanceResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {
        }


        public class Success : DistanceResponse
        {
            public Distance Distance { get; }

            internal Success(int statusCode, string reasonPhase, string raw, Distance distance) : base(statusCode, reasonPhase, raw, true)
            {
                Distance = distance;
                SuccessfulResult = this;
            }
        }


        public class Failed : DistanceResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }
    }


}
