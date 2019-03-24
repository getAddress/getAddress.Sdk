using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class DomainWhitelistService : IDomainWhitelistService
    {
        public AdminKey AdminKey { get; }

        public DomainWhitelistService(AdminKey adminKey)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }

        public async Task<AddDomainWhitelistResponse> Add(AddDomainWhitelistRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.DomainWhitelist.Add(request);
            }
        }

        public async Task<RemoveDomainWhitelistResponse> Remove(RemoveDomainWhitelistRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.DomainWhitelist.Remove(request);
            }
        }

        public async Task<ListDomainWhitelistResponse> List(AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.DomainWhitelist.List();
            }
        }

        public async Task<GetDomainWhitelistResponse> Get(GetDomainWhitelistRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.DomainWhitelist.Get(request);
            }
        }

        
    }
}
