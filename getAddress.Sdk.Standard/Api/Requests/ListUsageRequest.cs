using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Requests
{
    public class ListUsageRequest
    {

        [JsonProperty("to")]
        public DateValues To {get;set;}

        [JsonProperty("from")]
        public DateValues From {get;set;}

        public ListUsageRequest(int fromDay,int fromMonth, int fromYear,int toDay,int toMonth, int toYear)
        {
            To = new DateValues
                    {
                        Day = toDay,
                        Month = toMonth,
                        Year = toYear
                    };
            From = new DateValues
                    {
                        Day = fromDay,
                        Month = fromMonth,
                        Year = fromYear
                    };
        }


        public class DateValues 
        {
            [JsonProperty("day")]
            public int Day { get; set;}

            [JsonProperty("month")]
            public int Month { get; set;}

            [JsonProperty("year")]
            public int Year { get; set;}
        }
    }
}
