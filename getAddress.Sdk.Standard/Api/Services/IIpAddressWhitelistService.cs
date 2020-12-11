using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IIpAddressWhitelistService
    {
        Task<AddIpAddressWhitelistResponse> Add(AddIpAddressWhitelistRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<AddIpAddressWhitelistResponse> Add(AddIpAddressWhitelistRequest request, AccessToken accessToken, HttpClient httpClient = null);
        Task<GetIpAddressWhitelistResponse> Get(GetIpAddressWhitelistRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<GetIpAddressWhitelistResponse> Get(GetIpAddressWhitelistRequest request, AccessToken accessToken, HttpClient httpClient = null);
        Task<ListIpAddressWhitelistResponse> List(AdminKey adminKey = null, HttpClient httpClient = null);
        Task<ListIpAddressWhitelistResponse> List(AccessToken accessToken, HttpClient httpClient = null);
        Task<RemoveIpAddressWhitelistResponse> Remove(RemoveIpAddressWhitelistRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<RemoveIpAddressWhitelistResponse> Remove(RemoveIpAddressWhitelistRequest request, AccessToken accessToken, HttpClient httpClient = null);
    }
}