using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class DomainWhitelistService :ServiceBase, IDomainWhitelistService
    {

        public DomainWhitelistService(AdminKey adminKey, HttpClient httpClient = null):base(httpClient)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }
        public DomainWhitelistService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<AddDomainWhitelistResponse> Add(AddDomainWhitelistRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.DomainWhitelist.Add(request);
        }

        public async Task<RemoveDomainWhitelistResponse> Remove(RemoveDomainWhitelistRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.DomainWhitelist.Remove(request);
        }

        public async Task<ListDomainWhitelistResponse> List(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.DomainWhitelist.List();
        }

        public async Task<GetDomainWhitelistResponse> Get(GetDomainWhitelistRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.DomainWhitelist.Get(request);
        }

        
    }
}
