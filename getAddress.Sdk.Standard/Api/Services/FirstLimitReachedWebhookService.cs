using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class FirstLimitReachedWebhookService : IFirstLimitReachedWebhookService
    {
        public AdminKey AdminKey { get; }
        public HttpClient HttpClient { get; }

        public FirstLimitReachedWebhookService(AdminKey adminKey, HttpClient httpClient = null)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
            HttpClient = httpClient ?? throw new System.ArgumentNullException(nameof(httpClient));
        }

        public async Task<AddWebhookResponse> Add(AddWebhookRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey,httpClient))
            {
                return await api.FirstLimitReachedWebhook.Add(request);
            }
        }

        public async Task<RemoveWebhookResponse> Remove(RemoveWebhookRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey,httpClient))
            {
                return await api.FirstLimitReachedWebhook.Remove(request);
            }
        }

        public async Task<ListWebhookResponse> List(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey,httpClient))
            {
                return await api.FirstLimitReachedWebhook.List();
            }
        }

        public async Task<GetWebhookResponse> Get(GetWebhookRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey,httpClient))
            {
                return await api.FirstLimitReachedWebhook.Get(request);
            }
        }

        public async Task<TestWebhookResponse> Test(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey,httpClient))
            {
                return await api.FirstLimitReachedWebhook.Test();
            }
        }
    }
}
