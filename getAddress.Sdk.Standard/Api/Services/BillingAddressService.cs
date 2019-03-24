using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class BillingAddressService : IBillingAddressService
    {
        public AdminKey AdminKey { get; }

        public BillingAddressService(AdminKey adminKey)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }

        public async Task<BillingAddressResponse> Update(BillingAddressRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
               return await api.BillingAddress.Update(request);
            }
        }

        public async Task<BillingAddressResponse> Get(AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.BillingAddress.Get();
            }
        }
    
    }
}
