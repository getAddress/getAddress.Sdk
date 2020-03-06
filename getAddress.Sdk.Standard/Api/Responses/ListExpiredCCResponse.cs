using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListExpiredCCResponse : ResponseBase<ListExpiredCCResponse.Success, ListExpiredCCResponse.Failed>
    {

        protected ListExpiredCCResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : ListExpiredCCResponse
        {
            public IEnumerable<ExpiredCC> ExpiredCCs { get; }

            internal Success(int statusCode, string reasonPhrase, string raw, IEnumerable<ExpiredCC> expiredCCs) : base(statusCode, reasonPhrase, raw, true)
            {
                ExpiredCCs = expiredCCs;
                SuccessfulResult = this;
            }
        }

        public class Failed : ListExpiredCCResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}
