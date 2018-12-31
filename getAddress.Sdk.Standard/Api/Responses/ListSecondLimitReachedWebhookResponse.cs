using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListSecondLimitReachedWebhookResponse: ResponseBase<ListSecondLimitReachedWebhookResponse.Success,ListSecondLimitReachedWebhookResponse.Failed>
    {
        protected ListSecondLimitReachedWebhookResponse(int statusCode, string reasonPhase, string raw, bool isSuccess):base(statusCode,reasonPhase,raw,isSuccess)
        {
        
        }

        public class Success: ListSecondLimitReachedWebhookResponse
        {
            public IEnumerable<SecondLimitReachedWebhook> Webhooks { get; }

            internal Success(int statusCode, string reasonPhase, string raw, IEnumerable<SecondLimitReachedWebhook> webhooks) :base(statusCode, reasonPhase, raw,true)
            {
                Webhooks = webhooks;
                SuccessfulResult = this;
            }
        }

        public class Failed : ListSecondLimitReachedWebhookResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) :base(statusCode, reasonPhase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}
