using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class PrivateAddressService : IPrivateAddressService
    {
        public AdminKey AdminKey { get; }
        public HttpClient HttpClient { get; }

        public PrivateAddressService(AdminKey adminKey, HttpClient httpClient = null)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
            HttpClient = httpClient;
        }

        public async Task<AddPrivateAddressResponse> Add(AddPrivateAddressRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey,httpClient))
            {
                return await api.PrivateAddress.Add(request);
            }
        }

        public async Task<RemovePrivateAddressResponse> Remove(RemovePrivateAddressRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey,httpClient))
            {
                return await api.PrivateAddress.Remove(request);
            }
        }

        public async Task<ListPrivateAddressResponse> List(ListPrivateAddressRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey,httpClient))
            {
                return await api.PrivateAddress.List(request);
            }
        }

        public async Task<GetPrivateAddressResponse> Get(GetPrivateAddressRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey,httpClient))
            {
                return await api.PrivateAddress.Get(request);
            }
        }

    }
}
