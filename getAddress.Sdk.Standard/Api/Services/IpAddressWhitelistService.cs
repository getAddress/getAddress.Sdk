using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class IpAddressWhitelistService : IIpAddressWhitelistService
    {
        public AdminKey AdminKey { get; }
        public HttpClient HttpClient { get; }

        public IpAddressWhitelistService(AdminKey adminKey, HttpClient httpClient = null)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
            HttpClient = httpClient;
        }

        public async Task<AddIpAddressWhitelistResponse> Add(AddIpAddressWhitelistRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey,httpClient))
            {
                return await api.IpAddressWhitelist.Add(request);
            }
        }

        public async Task<RemoveIpAddressWhitelistResponse> Remove(RemoveIpAddressWhitelistRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey,httpClient))
            {
                return await api.IpAddressWhitelist.Remove(request);
            }
        }

        public async Task<ListIpAddressWhitelistResponse> List(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey??AdminKey,httpClient))
            {
                return await api.IpAddressWhitelist.List();
            }
        }

        public async Task<GetIpAddressWhitelistResponse> Get(GetIpAddressWhitelistRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey,httpClient))
            {
                return await api.IpAddressWhitelist.Get(request);
            }
        }

       
    }
}
