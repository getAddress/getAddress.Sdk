using System.Collections.Generic;
using System.Linq;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class ListFirstLimitReachedWebhookResponse: ResponseBase<ListFirstLimitReachedWebhookResponse.Success,ListFirstLimitReachedWebhookResponse.Failed>
    {

        protected ListFirstLimitReachedWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess):base(statusCode,reasonPhrase,raw,isSuccess)
        {
        
        }

        public class Success: ListFirstLimitReachedWebhookResponse
        {
            public IEnumerable<FirstLimitReachedWebhook> Webhooks { get; }

            public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<FirstLimitReachedWebhook> webhooks) :base(statusCode, reasonPhrase, raw,true)
            {
                Webhooks = webhooks;
                SuccessfulResult = this;
            }
        }

        public class Failed : ListFirstLimitReachedWebhookResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) :base(statusCode, reasonPhrase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }

    public abstract class ListWebhookResponse : ResponseBase<ListWebhookResponse.Success, ListWebhookResponse.Failed>
    {

        protected ListWebhookResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public ListFirstLimitReachedWebhookResponse FormerResult()
        {
            if (this.IsSuccess)
            {
                return new ListFirstLimitReachedWebhookResponse.Success(SuccessfulResult.StatusCode,
                    SuccessfulResult.ReasonPhrase, SuccessfulResult.Raw, this.SuccessfulResult.Webhooks.Select(w => new FirstLimitReachedWebhook {
                        Id = w.Id,
                        Url = w.Url
                    }));
            }
            else
            {
                return new ListFirstLimitReachedWebhookResponse.Failed(SuccessfulResult.StatusCode,
                    SuccessfulResult.ReasonPhrase, SuccessfulResult.Raw);
            }
        }


        public class Success : ListWebhookResponse
        {
            public IEnumerable<Webhook> Webhooks { get; }

            public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<Webhook> webhooks) : base(statusCode, reasonPhrase, raw, true)
            {
                Webhooks = webhooks;
                SuccessfulResult = this;
            }
        }

        public class Failed : ListWebhookResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}
