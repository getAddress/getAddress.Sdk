using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListFirstLimitReachedWebhookResponse: ResponseBase<ListFirstLimitReachedWebhookResponse.Success,ListFirstLimitReachedWebhookResponse.Failed>
    {

        protected ListFirstLimitReachedWebhookResponse(int statusCode, string reasonPhase, string raw, bool isSuccess):base(statusCode,reasonPhase,raw,isSuccess)
        {
        
        }

        public class Success: ListFirstLimitReachedWebhookResponse
        {
            public IEnumerable<FirstLimitReachedWebhook> Webhooks { get; }

            internal Success(int statusCode, string reasonPhase, string raw, IEnumerable<FirstLimitReachedWebhook> webhooks) :base(statusCode, reasonPhase, raw,true)
            {
                Webhooks = webhooks;
                SuccessfulResult = this;
            }
        }

        public class Failed : ListFirstLimitReachedWebhookResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) :base(statusCode, reasonPhase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}
