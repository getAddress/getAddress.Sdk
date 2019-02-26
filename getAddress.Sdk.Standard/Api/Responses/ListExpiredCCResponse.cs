using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListExpiredCCResponse : ResponseBase<ListExpiredCCResponse.Success, ListExpiredCCResponse.Failed>
    {

        protected ListExpiredCCResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        public class Success : ListExpiredCCResponse
        {
            public IEnumerable<ExpiredCC> ExpiredCCs { get; }

            internal Success(int statusCode, string reasonPhase, string raw, IEnumerable<ExpiredCC> expiredCCs) : base(statusCode, reasonPhase, raw, true)
            {
                ExpiredCCs = expiredCCs;
                SuccessfulResult = this;
            }
        }

        public class Failed : ListExpiredCCResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}
