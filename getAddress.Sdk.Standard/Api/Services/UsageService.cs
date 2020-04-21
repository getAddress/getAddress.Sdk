using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{

    public class UsageService : ServiceBase, IUsageService
    {

        public UsageService(HttpClient httpClient = null) : base(httpClient)
        {
            
        }

        public UsageService(AdminKey adminKey, HttpClient httpClient = null):base(httpClient)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }

        public UsageService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken,httpClient)
        {

        }

        public async Task<GetUsageV3Response> GetV3(AccessToken accessToken, HttpClient httpClient = null)
        {
            var api =  new GetAddesssApi(accessToken, HttpClient ?? httpClient);

            return await api.Usage.GetV3();
        }

        public async Task<GetUsageV3Response> GetV3(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.Usage.GetV3();
        }

        

        public async Task<GetUsageResponse> Get(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.Usage.Get();
        }

        public async Task<GetUsageResponse> Get(GetUsageRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.Usage.Get(request);
        }

        public async Task<GetUsageV3Response> GetV3(GetUsageRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.Usage.GetV3(request);
        }


        public async Task<ListUsageResponse> List(ListUsageRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);
           
            return await api.Usage.List(request);
        }
    }
}
