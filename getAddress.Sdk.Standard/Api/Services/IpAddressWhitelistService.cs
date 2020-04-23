using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class IpAddressWhitelistService : ServiceBase, IIpAddressWhitelistService
    {
        public IpAddressWhitelistService(HttpClient httpClient) : base(httpClient)
        {

        }
        public IpAddressWhitelistService() : base(null)
        {

        }
        public IpAddressWhitelistService(AdminKey adminKey, HttpClient httpClient = null):base(httpClient)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }
        public IpAddressWhitelistService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<AddIpAddressWhitelistResponse> Add(AddIpAddressWhitelistRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.IpAddressWhitelist.Add(request);
        }

        public async Task<RemoveIpAddressWhitelistResponse> Remove(RemoveIpAddressWhitelistRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.IpAddressWhitelist.Remove(request);
        }

        public async Task<ListIpAddressWhitelistResponse> List(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.IpAddressWhitelist.List();
        }

        public async Task<GetIpAddressWhitelistResponse> Get(GetIpAddressWhitelistRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.IpAddressWhitelist.Get(request);
        }

       
    }
}
