using getAddress.Sdk.Api.Responses;
using System.Collections.Generic;

public class ListUsage
{
    public int Count { get; set; }

    public System.DateTime Date { get; set; }
}

public abstract class ListUsageResponse : ResponseBase<ListUsageResponse.Success, ListUsageResponse.Failed>
{

    protected ListUsageResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
    {

    }

    public class Success : ListUsageResponse
    {
        public IEnumerable<ListUsage> Usages {get;}
        
        public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<ListUsage> usages) : base(statusCode, reasonPhrase, raw, true)
        {
            
            SuccessfulResult = this;
            Usages = usages ?? throw new System.ArgumentNullException(nameof(usages));
        }
    }

    public class Failed : ListUsageResponse
    {
        public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
        {
            FailedResult = this;
        }
    }
}