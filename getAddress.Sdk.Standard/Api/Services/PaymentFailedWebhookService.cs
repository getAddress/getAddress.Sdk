using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class PaymentFailedWebhookService : IPaymentFailedWebhookService
    {
        public AdminKey AdminKey { get; }

        public PaymentFailedWebhookService(AdminKey adminKey)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }

        public async Task<AddWebhookResponse> Add(AddWebhookRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.PaymentFailedWebhook.Add(request);
            }
        }

        public async Task<RemoveWebhookResponse> Remove(RemoveWebhookRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.PaymentFailedWebhook.Remove(request);
            }
        }

        public async Task<ListWebhookResponse> List(AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.PaymentFailedWebhook.List();
            }
        }

        public async Task<GetWebhookResponse> Get(GetWebhookRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.PaymentFailedWebhook.Get(request);
            }
        }

        public async Task<TestWebhookResponse> Test(AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.PaymentFailedWebhook.Test();
            }
        }
    }
}
