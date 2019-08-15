using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Threading.Tasks;
using System.Net.Http;

namespace getAddress.Sdk.Api
{
    public class DistanceService : IDistanceService
    {
        public AdminKey AdminKey { get; }
        public HttpClient HttpClient { get; }

        public DistanceService(AdminKey adminKey, HttpClient httpClient = null)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
            HttpClient = httpClient;
        }


        public async Task<DistanceResponse> Get(DistanceRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey, httpClient))
            {
                return await api.Distance.Get(request);
            }
        }

       
    }
}
