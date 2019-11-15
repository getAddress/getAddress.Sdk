using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class BillingAddressService : IBillingAddressService
    {
        public AdminKey AdminKey { get; }
        public HttpClient HttpClient { get; }

        public BillingAddressService(AdminKey adminKey, HttpClient httpClient = null)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
            HttpClient = httpClient;
        }

        public async Task<BillingAddressResponse> Update(BillingAddressRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey, HttpClient ?? httpClient))
            {
               return await api.BillingAddress.Update(request);
            }
        }

        public async Task<BillingAddressResponse> Get(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey, HttpClient ?? httpClient))
            {
                return await api.BillingAddress.Get();
            }
        }
    
    }
}
