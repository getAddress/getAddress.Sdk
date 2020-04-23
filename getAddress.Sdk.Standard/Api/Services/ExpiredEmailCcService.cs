using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class ExpiredEmailCcService : ServiceBase, IExpiredEmailCcService
    {
        public ExpiredEmailCcService(HttpClient httpClient) : base(httpClient)
        {

        }
        public ExpiredEmailCcService() : base(null)
        {

        }
        public ExpiredEmailCcService(AdminKey adminKey, HttpClient httpClient = null):base(httpClient)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }
        public ExpiredEmailCcService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<AddExpiredCCResponse> Add(AddExpiredCCRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.ExpiredCC.Add(request);
        }

        public async Task<RemoveExpiredCCResponse> Remove(RemoveExpiredCCRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.ExpiredCC.Remove(request);
        }

        public async Task<ListExpiredCCResponse> List(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.ExpiredCC.List();
        }

        public async Task<GetExpiredCCResponse> Get(GetExpiredCCRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.ExpiredCC.Get(request);
        }
    }
}
