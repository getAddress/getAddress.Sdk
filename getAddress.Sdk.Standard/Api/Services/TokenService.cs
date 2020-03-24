using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class TokenService
    {
        public TokenService(AdminKey adminKey, HttpClient httpClient = null)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
            HttpClient = httpClient;
        }

        public AdminKey AdminKey { get; }
        public HttpClient HttpClient { get; }

        public async Task<GetTokenResponse> Get(AdminKey apiKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(apiKey ?? AdminKey, HttpClient ?? httpClient))
            {
                return await api.Token.Get();
            }
        }

        public async Task<RefreshTokenResponse> Refresh(RefreshToken token, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(AdminKey, HttpClient ?? httpClient))
            {
                return await api.Token.Refresh(token);
            }
        }

        public async Task<RevokeTokenResponse> Revoke(AdminKey apiKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(apiKey ?? AdminKey, HttpClient ?? httpClient))
            {
                return await api.Token.Revoke();
            }
        }
    }
}
