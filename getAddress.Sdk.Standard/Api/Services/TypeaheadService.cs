using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api.Services
{
    public class TypeaheadService : ServiceBase, ITypeaheadService
    {
        public TypeaheadService(HttpClient httpClient) : base(httpClient)
        {

        }
        public TypeaheadService() : base(null)
        {

        }

        public TypeaheadService(ApiKey apiKey, HttpClient httpClient = null) : base(httpClient)
        {
            ApiKey = apiKey ?? throw new System.ArgumentNullException(nameof(apiKey));
        }

        public TypeaheadService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<TypeaheadResponse> List(AccessToken accessToken, string term, TypeaheadOptions options = null, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, HttpClient ?? httpClient);

            return await api.TypeaheadApi.List(term, options);
        }

        public async Task<TypeaheadResponse> List(string term, TypeaheadOptions options = null, ApiKey apiKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(apiKey, httpClient);

            return await api.TypeaheadApi.List(term, options);
        }
    }
}
