using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class UsageService : IUsageService
    {
        public UsageService(AdminKey adminKey, HttpClient httpClient = null)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
            HttpClient = httpClient;
        }

        public AdminKey AdminKey { get; }
        public HttpClient HttpClient { get; }

        public async Task<GetUsageResponse> Get(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey??AdminKey, HttpClient ?? httpClient))
            {
                return await api.Usage.Get();
            }
        }

        public async Task<GetUsageResponse> Get(GetUsageRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey??AdminKey, HttpClient ?? httpClient))
            {
                return await api.Usage.Get(request);
            }
        }

       
        public async Task<ListUsageResponse> List(ListUsageRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey, HttpClient ?? httpClient))
            {
                return await api.Usage.List(request);
            }
        }
    }
}
