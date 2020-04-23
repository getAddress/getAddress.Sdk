using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Threading.Tasks;
using System.Net.Http;

namespace getAddress.Sdk.Api
{
    public class DistanceService : ServiceBase, IDistanceService
    {
        public DistanceService(HttpClient httpClient) : base(httpClient)
        {

        }
        public DistanceService() : base(null)
        {

        }

        public DistanceService(ApiKey apiKey, HttpClient httpClient = null):base(httpClient)
        {
            ApiKey = apiKey ?? throw new System.ArgumentNullException(nameof(apiKey));
        }
        public DistanceService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<DistanceResponse> Get(DistanceRequest request, ApiKey apiKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(apiKey, httpClient);

            return await api.Distance.Get(request);
        }

       
    }
}
