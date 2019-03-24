using System;

namespace getAddress.Sdk.Api.Requests
{
    public class GetUsageRequest
    {
        public GetUsageRequest(int day, int month, int year)
        {
           DateTime = new DateTime(year, month, day);
            Day = day;
            Month = month;
            Year = year;
        }

        public DateTime DateTime
        {
            get;
        }
        public int Day { get; }
        public int Month { get; }
        public int Year { get; }
    }
}
