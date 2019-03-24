using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class PrivateAddressService : IPrivateAddressService
    {
        public AdminKey AdminKey { get; }

        public PrivateAddressService(AdminKey adminKey)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }

        public async Task<AddPrivateAddressResponse> Add(AddPrivateAddressRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.PrivateAddress.Add(request);
            }
        }

        public async Task<RemovePrivateAddressResponse> Remove(RemovePrivateAddressRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.PrivateAddress.Remove(request);
            }
        }

        public async Task<ListPrivateAddressResponse> List(ListPrivateAddressRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.PrivateAddress.List(request);
            }
        }

        public async Task<GetPrivateAddressResponse> Get(GetPrivateAddressRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.PrivateAddress.Get(request);
            }
        }

    }
}
