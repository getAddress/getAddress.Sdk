using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IIpAddressWhitelistService
    {
        Task<AddIpAddressWhitelistResponse> Add(AddIpAddressWhitelistRequest request, AdminKey adminKey = null);
        Task<GetIpAddressWhitelistResponse> Get(GetIpAddressWhitelistRequest request, AdminKey adminKey = null);
        Task<ListIpAddressWhitelistResponse> List(AdminKey adminKey = null);
        Task<RemoveIpAddressWhitelistResponse> Remove(RemoveIpAddressWhitelistRequest request, AdminKey adminKey = null);
    }
}