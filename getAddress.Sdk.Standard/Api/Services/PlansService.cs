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

        public async Task<PlansResponse> Get(HttpClient httpClient = null)
        {
            var api = GetAddesssApi(httpClient: httpClient);

            return await api.Plans.Get();
        }
    }
}
