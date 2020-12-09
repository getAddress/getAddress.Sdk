using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class PlansService : ServiceBase, IPlansService
    {
        public PlansService(HttpClient httpClient) : base(httpClient)
        {

        }
        public PlansService() : base(null)
        {

        }

        public async Task<PlansResponse> Get(AdminKey adminKey, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient: httpClient);

            return await api.Plans.Get();
        }

        public async Task<PlansResponse> Get(AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.Plans.Get();
        }
    }
}
