using getAddress.Sdk.Api.Responses;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class ApiKeyService : IApiKeyService
    {
        public AdminKey AdminKey { get; }

        public ApiKeyService(AdminKey adminKey)
        {
            AdminKey = adminKey;
        }

        public async Task<ApiKeyResponse> Update(AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.ApiKeyApi.Update();
            }
        }

        public async Task<ApiKeyResponse> Get(AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.ApiKeyApi.Get();
            }
        }

    }
}
