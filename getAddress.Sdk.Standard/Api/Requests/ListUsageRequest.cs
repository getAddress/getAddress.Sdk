using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Requests
{
    public class ListUsageRequest: RangeRequest
    {
        public ListUsageRequest(int fromDay,int fromMonth, int fromYear,int toDay,int toMonth, int toYear)
            :base(fromDay,fromMonth,fromYear,toDay,toMonth,toYear)
        {
           
        }
    }
}
