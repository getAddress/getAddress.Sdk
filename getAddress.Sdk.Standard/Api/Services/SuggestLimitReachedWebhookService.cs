using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class SuggestLimitReachedWebhookService : ServiceBase, ITrackWebhookService
    {
        public SuggestLimitReachedWebhookService(HttpClient httpClient) : base(httpClient)
        {

        }
        public SuggestLimitReachedWebhookService() : base(null)
        {

        }
        public SuggestLimitReachedWebhookService(AdminKey adminKey, HttpClient httpClient = null) : base(httpClient)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }

        public SuggestLimitReachedWebhookService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<AddWebhookResponse> Add(AddWebhookRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.SuggestLimitReachedWebhook.Add(request);
        }

        public async Task<RemoveWebhookResponse> Remove(RemoveWebhookRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.SuggestLimitReachedWebhook.Remove(request);
        }

        public async Task<ListWebhookResponse> List(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.SuggestLimitReachedWebhook.List();
        }

        public async Task<GetWebhookResponse> Get(GetWebhookRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.SuggestLimitReachedWebhook.Get(request);
        }

        public async Task<TestWebhookResponse> Test(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.SuggestLimitReachedWebhook.Test();
        }
    }
}
