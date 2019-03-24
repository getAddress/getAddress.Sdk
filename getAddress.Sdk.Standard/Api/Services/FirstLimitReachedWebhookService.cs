using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class FirstLimitReachedWebhookService : IFirstLimitReachedWebhookService
    {
        public AdminKey AdminKey { get; }

        public FirstLimitReachedWebhookService(AdminKey adminKey)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }

        public async Task<AddWebhookResponse> Add(AddWebhookRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.FirstLimitReachedWebhook.Add(request);
            }
        }

        public async Task<RemoveWebhookResponse> Remove(RemoveWebhookRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.FirstLimitReachedWebhook.Remove(request);
            }
        }

        public async Task<ListWebhookResponse> List(AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.FirstLimitReachedWebhook.List();
            }
        }

        public async Task<GetWebhookResponse> Get(GetWebhookRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.FirstLimitReachedWebhook.Get(request);
            }
        }

        public async Task<TestWebhookResponse> Test(AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.FirstLimitReachedWebhook.Test();
            }
        }
    }
}
