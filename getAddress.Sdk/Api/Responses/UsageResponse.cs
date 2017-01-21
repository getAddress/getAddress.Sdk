using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api.Responses
{

    public abstract class GetUsageResponse : AdminResponse
    {

        protected GetUsageResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        public class Success : GetUsageResponse
        {
            public int DailyRequestCount { get; set; }

            public int DailyRequestLimit1 { get; set; }

            public int DailyRequestLimit2 { get; set; }

            internal Success(int statusCode, string reasonPhase, string raw, int counter, int limit1, int limit2) : base(statusCode, reasonPhase, raw, true)
            {
                DailyRequestCount = counter;
                DailyRequestLimit1 = limit1;
                DailyRequestLimit2 = limit2;
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
