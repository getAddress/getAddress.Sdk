using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class ApiKeyService : IApiKeyService
    {
        public AdminKey AdminKey { get; }
        public HttpClient HttpClient { get; }

        public ApiKeyService(AdminKey adminKey,HttpClient httpClient = null)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
            HttpClient = httpClient ?? throw new System.ArgumentNullException(nameof(httpClient));
        }

        public async Task<ApiKeyResponse> Update(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey, httpClient))
            {
                return await api.ApiKeyApi.Update();
            }
        }

        public async Task<ApiKeyResponse> Get(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey,httpClient))
            {
                return await api.ApiKeyApi.Get();
            }
        }

    }
}
