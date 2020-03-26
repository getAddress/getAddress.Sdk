using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class AddressService : ServiceBase, IAddressService
    {
        public AddressService(ApiKey apiKey, HttpClient httpClient = null):base(httpClient)
        {
            ApiKey = apiKey ?? throw new System.ArgumentNullException(nameof(apiKey));
        }
        public AddressService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<GetAddressResponse> Get(GetAddressRequest request, ApiKey apiKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(apiKey, httpClient);
            
            return await api.Address.Get(request);
        }

        public async Task<GetExpandedAddressResponse> GetExpanded(GetAddressRequest request, ApiKey apiKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(apiKey, httpClient);

            return await api.Address.GetExpanded(request);
        }

        public async Task<PlaceDetailsResponse> PlaceDetails(PlaceDetailsRequest request, ApiKey apiKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(apiKey, httpClient);

            return await api.Address.PlaceDetails(request);
        }
    }
}
