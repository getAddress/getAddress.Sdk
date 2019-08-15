using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IPrivateAddressService
    {
        Task<AddPrivateAddressResponse> Add(AddPrivateAddressRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<GetPrivateAddressResponse> Get(GetPrivateAddressRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<ListPrivateAddressResponse> List(ListPrivateAddressRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<RemovePrivateAddressResponse> Remove(RemovePrivateAddressRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
    }
}