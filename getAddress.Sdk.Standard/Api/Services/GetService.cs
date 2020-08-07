using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api.Services
{
    public class GetService : ServiceBase, IGetService
    {
        public GetService(HttpClient httpClient) : base(httpClient)
        {

        }
        public GetService() : base(null)
        {

        }

        public GetService(ApiKey apiKey, HttpClient httpClient = null) : base(httpClient)
        {
            ApiKey = apiKey ?? throw new System.ArgumentNullException(nameof(apiKey));
        }

        public GetService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<GetResponse> Get(Suggestion suggestion, ApiKey apiKey = null, HttpClient httpClient = null)
        {
            return await Get(suggestion.Id, apiKey: apiKey, httpClient: httpClient);
        }

        public async Task<GetResponse> Get(string id, ApiKey apiKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(apiKey, httpClient);

            return await api.Get.Address(id);
        }
    }
}
