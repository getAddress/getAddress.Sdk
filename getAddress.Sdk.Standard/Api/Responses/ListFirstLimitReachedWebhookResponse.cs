using System.Collections.Generic;
using System.Linq;

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

    public abstract class ListWebhookResponse : ResponseBase<ListWebhookResponse.Success, ListWebhookResponse.Failed>
    {

        protected ListWebhookResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        internal ListFirstLimitReachedWebhookResponse FormerResult()
        {
            if (this.IsSuccess)
            {
                return new ListFirstLimitReachedWebhookResponse.Success(SuccessfulResult.StatusCode,
                    SuccessfulResult.ReasonPhase, SuccessfulResult.Raw, this.SuccessfulResult.Webhooks.Select(w => new FirstLimitReachedWebhook {
                        Id = w.Id,
                        Url = w.Url
                    }));
            }
            else
            {
                return new ListFirstLimitReachedWebhookResponse.Failed(SuccessfulResult.StatusCode,
                    SuccessfulResult.ReasonPhase, SuccessfulResult.Raw);
            }
        }


        public class Success : ListWebhookResponse
        {
            public IEnumerable<Webhook> Webhooks { get; }

            internal Success(int statusCode, string reasonPhase, string raw, IEnumerable<Webhook> webhooks) : base(statusCode, reasonPhase, raw, true)
            {
                Webhooks = webhooks;
                SuccessfulResult = this;
            }
        }

        public class Failed : ListWebhookResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}
