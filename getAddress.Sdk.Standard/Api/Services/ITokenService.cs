using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public interface ITokenService
    {
        Task<GetTokenResponse> Get(AdminKey apiKey = null, HttpClient httpClient = null);
        Task<RefreshTokenResponse> Refresh(RefreshToken token, HttpClient httpClient = null);
        Task<RevokeTokenResponse> Revoke(AdminKey apiKey = null, HttpClient httpClient = null);
    }
}