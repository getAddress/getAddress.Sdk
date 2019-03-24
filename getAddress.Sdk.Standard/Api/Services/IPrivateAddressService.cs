using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IPrivateAddressService
    {
        Task<AddPrivateAddressResponse> Add(AddPrivateAddressRequest request, AdminKey adminKey = null);
        Task<GetPrivateAddressResponse> Get(GetPrivateAddressRequest request, AdminKey adminKey = null);
        Task<ListPrivateAddressResponse> List(ListPrivateAddressRequest request, AdminKey adminKey = null);
        Task<RemovePrivateAddressResponse> Remove(RemovePrivateAddressRequest request, AdminKey adminKey = null);
    }
}