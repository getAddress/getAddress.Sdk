using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class AutocompleteService
    {
        public ApiKey ApiKey { get; }
        public HttpClient HttpClient { get; }

        public AutocompleteService(ApiKey apiKey, HttpClient httpClient = null)
        {
            ApiKey = apiKey ?? throw new System.ArgumentNullException(nameof(apiKey));
            HttpClient = httpClient;
        }


        public async Task<AutocompletePostcodeResponse> Postcodes(AutocompleteRequest request, ApiKey apiKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(apiKey ?? ApiKey, HttpClient ?? httpClient))
            {
                return await api.Autocomplete.Postcodes(request);
            }
        }
        public async Task<AutocompleteResponse> Palaces(AutocompleteRequest request, ApiKey apiKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(apiKey ?? ApiKey, HttpClient ?? httpClient))
            {
                return await api.Autocomplete.Places(request);
            }
        }

    }
}
