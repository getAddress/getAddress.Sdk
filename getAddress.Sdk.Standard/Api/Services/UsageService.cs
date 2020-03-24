using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class UsageService : IUsageService
    {
        private UsageService(HttpClient httpClient = null)
        {
            HttpClient = httpClient;
        }

        public UsageService(AdminKey adminKey, HttpClient httpClient = null):this(httpClient)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }

        public UsageService(AccessToken accessToken,  HttpClient httpClient = null) : this(httpClient)
        {
            AccessToken = accessToken ?? throw new System.ArgumentNullException(nameof(accessToken));
        }

        public AccessToken AccessToken { get; }

        public AdminKey AdminKey { get; }
        public HttpClient HttpClient { get; }

        public async Task<GetUsageV3Response> GetV3(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.Usage.GetV3();
        }

        private GetAddesssApi GetAddesssApi(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            if (AccessToken != null && adminKey == null)
            {
                return new GetAddesssApi(AccessToken, HttpClient ?? httpClient);
            }
            else
            {
                return new GetAddesssApi(adminKey ?? AdminKey, HttpClient ?? httpClient);
            } 
        }

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

        public async Task<GetUsageV3Response> GetV3(GetUsageRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey, HttpClient ?? httpClient))
            {
                return await api.Usage.GetV3(request);
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
