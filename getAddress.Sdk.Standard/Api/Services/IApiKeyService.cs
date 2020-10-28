using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IApiKeyService
    {
        Task<ApiKeyResponse> Get(AdminKey adminKey = null, HttpClient httpClient = null);
        Task<ApiKeyResponse> Get(AccessToken accessToken, HttpClient httpClient = null);
        Task<ApiKeyResponse> Update(AdminKey adminKey = null, HttpClient httpClient = null);
        Task<ApiKeyResponse> Update(AccessToken accessToken, HttpClient httpClient = null);
    }
}