using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class UsageService : IUsageService
    {
        public UsageService(AdminKey adminKey)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }

        public AdminKey AdminKey { get; }

        public async Task<GetUsageResponse> Get(AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.Usage.Get();
            }
        }

        public async Task<GetUsageResponse> Get(GetUsageRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.Usage.Get(request);
            }
        }

    }
}
