namespace getAddress.Sdk.Api.Requests
{
    public class ListInvoicesRequest : RangeRequest
    {
        public ListInvoicesRequest(int fromDay, int fromMonth, int fromYear, int toDay, int toMonth, int toYear)
            : base(fromDay, fromMonth, fromYear, toDay, toMonth, toYear)
        {

        }
    }
}
