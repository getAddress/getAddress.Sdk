using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class AddressService : IAddressService
    {
        public AddressService(ApiKey apiKey, HttpClient httpClient = null)
        {
            ApiKey = apiKey ?? throw new System.ArgumentNullException(nameof(apiKey));
            HttpClient = httpClient;
        }

        public ApiKey ApiKey { get; }
        public HttpClient HttpClient { get; }

        public async Task<GetAddressResponse> Get(GetAddressRequest request, ApiKey apiKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(apiKey ?? ApiKey,httpClient))
            {
                return await api.Address.Get(request);
            }
        }

        public async Task<GetExpandedAddressResponse> GetExpanded(GetAddressRequest request, ApiKey apiKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(apiKey ?? ApiKey,httpClient))
            {
                return await api.Address.GetExpanded(request);
            }
        }
    }
}
