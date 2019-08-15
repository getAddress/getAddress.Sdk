using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IDomainWhitelistService
    {
        Task<AddDomainWhitelistResponse> Add(AddDomainWhitelistRequest request, AdminKey adminKey = null,HttpClient httpClient = null);
        Task<GetDomainWhitelistResponse> Get(GetDomainWhitelistRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<ListDomainWhitelistResponse> List(AdminKey adminKey = null, HttpClient httpClient = null);
        Task<RemoveDomainWhitelistResponse> Remove(RemoveDomainWhitelistRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
    }
}