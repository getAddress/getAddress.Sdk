using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public interface IAutocompleteService
    {
        Task<AutocompleteResponse> Palaces(AutocompleteRequest request, ApiKey apiKey = null, HttpClient httpClient = null);
        Task<AutocompletePostcodeResponse> Postcodes(AutocompleteRequest request, ApiKey apiKey = null, HttpClient httpClient = null);
    }

    public class AutocompleteService : ServiceBase, IAutocompleteService
    {
        public AutocompleteService(ApiKey apiKey, HttpClient httpClient = null) : base(httpClient)
        {
            ApiKey = apiKey ?? throw new System.ArgumentNullException(nameof(apiKey));
        }
        public AutocompleteService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<AutocompletePostcodeResponse> Postcodes(AutocompleteRequest request, ApiKey apiKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(apiKey, httpClient);

            return await api.Autocomplete.Postcodes(request);
        }
        public async Task<AutocompleteResponse> Palaces(AutocompleteRequest request, ApiKey apiKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(apiKey, httpClient);

            return await api.Autocomplete.Places(request);
        }

    }
}
