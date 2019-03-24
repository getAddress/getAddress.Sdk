using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IBillingAddressService
    {
        Task<BillingAddressResponse> Get(AdminKey adminKey = null);
        Task<BillingAddressResponse> Update(BillingAddressRequest request, AdminKey adminKey = null);
    }
}