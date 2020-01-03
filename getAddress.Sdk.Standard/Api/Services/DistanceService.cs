using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Threading.Tasks;
using System.Net.Http;

namespace getAddress.Sdk.Api
{
    public class DistanceService : IDistanceService
    {
        public ApiKey ApiKey { get; }
        public HttpClient HttpClient { get; }

        public DistanceService(ApiKey apiKey, HttpClient httpClient = null)
        {
            ApiKey = apiKey ?? throw new System.ArgumentNullException(nameof(apiKey));
            HttpClient = httpClient;
        }


        public async Task<DistanceResponse> Get(DistanceRequest request, ApiKey apiKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(apiKey ?? ApiKey, HttpClient ?? httpClient))
            {
                return await api.Distance.Get(request);
            }
        }

       
    }
}
