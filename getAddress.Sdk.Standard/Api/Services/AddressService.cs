using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class AddressService : IAddressService
    {
        public AddressService(ApiKey apiKey)
        {
            ApiKey = apiKey ?? throw new System.ArgumentNullException(nameof(apiKey));
        }

        public ApiKey ApiKey { get; }

        public async Task<GetAddressResponse> Get(GetAddressRequest request, ApiKey apiKey = null)
        {
            using (var api = new GetAddesssApi(apiKey ?? ApiKey))
            {
                return await api.Address.Get(request);
            }
        }

        public async Task<GetExpandedAddressResponse> GetExpanded(GetAddressRequest request, ApiKey apiKey = null)
        {
            using (var api = new GetAddesssApi(apiKey ?? ApiKey))
            {
                return await api.Address.GetExpanded(request);
            }
        }
    }
}
