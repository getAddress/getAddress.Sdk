using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IAddressService
    {
        ApiKey ApiKey { get; }

        Task<GetAddressResponse> Get(GetAddressRequest request, ApiKey apiKey = null);
        Task<GetExpandedAddressResponse> GetExpanded(GetAddressRequest request, ApiKey apiKey = null);
    }
}