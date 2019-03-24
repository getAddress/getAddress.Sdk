using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class IpAddressWhitelistService : IIpAddressWhitelistService
    {
        public AdminKey AdminKey { get; }

        public IpAddressWhitelistService(AdminKey adminKey)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }

        public async Task<AddIpAddressWhitelistResponse> Add(AddIpAddressWhitelistRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey))
            {
                return await api.IpAddressWhitelist.Add(request);
            }
        }

        public async Task<RemoveIpAddressWhitelistResponse> Remove(RemoveIpAddressWhitelistRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey))
            {
                return await api.IpAddressWhitelist.Remove(request);
            }
        }

        public async Task<ListIpAddressWhitelistResponse> List(AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey))
            {
                return await api.IpAddressWhitelist.List();
            }
        }

        public async Task<GetIpAddressWhitelistResponse> Get(GetIpAddressWhitelistRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey))
            {
                return await api.IpAddressWhitelist.Get(request);
            }
        }

       
    }
}
