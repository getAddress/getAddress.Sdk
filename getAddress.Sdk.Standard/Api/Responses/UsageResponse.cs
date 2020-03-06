using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Responses
{
    public class Usage
    {
        public int Count { get; set; }

        public int Limit1 { get; set; }

        public int Limit2 { get; set; }
    }

    public class UsageV3
    {
        [JsonProperty("usage_today")]
        public int UsageToday { get; set; }

        [JsonProperty("daily_limit")]
        public int DailyLimit { get; set; }

        [JsonProperty("monthly_buffer")]
        public int MonthlyBuffer { get; set; }

        [JsonProperty("monthly_buffer_used")]
        public int MonthlyBufferUsed { get; set; }
    }

    public abstract class GetUsageResponse : ResponseBase<GetUsageResponse.Success,GetUsageResponse.Failed>
    {

        protected GetUsageResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : GetUsageResponse
        {
            public Usage Usage { get; set; }

            internal Success(int statusCode, string reasonPhrase, string raw, int counter, int limit1, int limit2) : base(statusCode, reasonPhrase, raw, true)
            {
                Usage = new Usage {
                    Count = counter,
                    Limit1 = limit1,
                    Limit2 = limit2
                };
                SuccessfulResult = this;
            }
        }

        public class Failed : GetUsageResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }

    public abstract class GetUsageV3Response : ResponseBase<GetUsageV3Response.Success, GetUsageV3Response.Failed>
    {

        protected GetUsageV3Response(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : GetUsageV3Response
        {
            public UsageV3 Usage { get; set; }

            internal Success(int statusCode, string reasonPhrase, string raw, int dailyLimit, int usageToday, int monthlyBuffer,int monthlyBufferUsed) : base(statusCode, reasonPhrase, raw, true)
            {
                Usage = new UsageV3
                {
                    DailyLimit = dailyLimit,
                    UsageToday = usageToday,
                    MonthlyBuffer = monthlyBuffer,
                    MonthlyBufferUsed = monthlyBufferUsed
                };
                SuccessfulResult = this;
            }
        }

        public class Failed : GetUsageV3Response
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                FailedResult = this;
            }
        }
    }

}
