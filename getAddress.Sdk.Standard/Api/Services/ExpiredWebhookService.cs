using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class ExpiredWebhookService : IExpiredWebhookService
    {
        public AdminKey AdminKey { get; }
        public HttpClient HttpClient { get; }

        public ExpiredWebhookService(AdminKey adminKey, HttpClient httpClient = null)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
            HttpClient = httpClient;
        }

        public async Task<AddWebhookResponse> Add(AddWebhookRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey, HttpClient ?? httpClient))
            {
                return await api.ExpiredWebhook.Add(request);
            }
        }

        public async Task<RemoveWebhookResponse> Remove(RemoveWebhookRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey, HttpClient ?? httpClient))
            {
                return await api.ExpiredWebhook.Remove(request);
            }
        }

        public async Task<ListWebhookResponse> List(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey, HttpClient ?? httpClient))
            {
                return await api.ExpiredWebhook.List();
            }
        }

        public async Task<GetWebhookResponse> Get(GetWebhookRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey, HttpClient ?? httpClient))
            {
                return await api.ExpiredWebhook.Get(request);
            }
        }

        public async Task<TestWebhookResponse> Test(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey, HttpClient ?? httpClient))
            {
                return await api.ExpiredWebhook.Test();
            }
        }
    }
}
