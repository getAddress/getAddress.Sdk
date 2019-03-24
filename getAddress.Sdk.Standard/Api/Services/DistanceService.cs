using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class DistanceService : IDistanceService
    {
        public AdminKey AdminKey { get; }

        public DistanceService(AdminKey adminKey)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }

        public async Task<DistanceResponse> Get(DistanceRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.Distance.Get(request);
            }
        }

       
    }
}
