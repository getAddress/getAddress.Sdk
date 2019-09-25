using getAddress.Sdk.Api.Responses;
using System.Collections.Generic;

public class ListUsage
{
    public int Count { get; set; }

    public System.DateTime Date { get; set; }
}

public abstract class ListUsageResponse : ResponseBase<ListUsageResponse.Success, ListUsageResponse.Failed>
{

    protected ListUsageResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
    {

    }

    public class Success : ListUsageResponse
    {

        public IEnumerable<ListUsage> Usages {get;}
        internal Success(int statusCode, string reasonPhase, string raw, IEnumerable<ListUsage> usages) : base(statusCode, reasonPhase, raw, true)
        {
            
            SuccessfulResult = this;
            Usages = usages ?? throw new System.ArgumentNullException(nameof(usages));
        }
    }

    public class Failed : ListUsageResponse
    {
        internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
        {
            FailedResult = this;
        }
    }
}