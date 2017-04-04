namespace getAddress.Sdk.Api.Responses
{
    public class Usage
    {
        public int Count { get; set; }

        public int Limit1 { get; set; }

        public int Limit2 { get; set; }
    }

    public abstract class GetUsageResponse : AdminResponse
    {

        protected GetUsageResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        public class Success : GetUsageResponse
        {
            public Usage Usage { get; set; }

            internal Success(int statusCode, string reasonPhase, string raw, int counter, int limit1, int limit2) : base(statusCode, reasonPhase, raw, true)
            {
                Usage = new Usage {
                    Count = counter,
                    Limit1 = limit1,
                    Limit2 = limit2
                };
            }
        }

        public class Failed : GetUsageResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {

            }
        }
    }
}
