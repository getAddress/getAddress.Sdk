using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class ExpiredEmailCcService : IExpiredEmailCcService
    {
        public AdminKey AdminKey { get; }

        public ExpiredEmailCcService(AdminKey adminKey)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }

        public async Task<AddExpiredCCResponse> Add(AddExpiredCCRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.ExpiredCC.Add(request);
            }
        }

        public async Task<RemoveExpiredCCResponse> Remove(RemoveExpiredCCRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.ExpiredCC.Remove(request);
            }
        }

        public async Task<ListExpiredCCResponse> List(AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.ExpiredCC.List();
            }
        }

        public async Task<GetExpiredCCResponse> Get(GetExpiredCCRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.ExpiredCC.Get(request);
            }
        }
    }
}
