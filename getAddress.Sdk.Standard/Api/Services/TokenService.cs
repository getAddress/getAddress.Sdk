using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class TokenService : ServiceBase, ITokenService
    {
        public TokenService(HttpClient httpClient) : base(httpClient)
        {

        }
        public TokenService() : base(null)
        {

        }

        public TokenService(AdminKey adminKey, HttpClient httpClient = null):base(httpClient)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }


        public async Task<GetTokenResponse> Get(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.Token.Get();
        }


        public async Task<RefreshTokenResponse> Refresh(RefreshToken token, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(AdminKey, httpClient);

            return await api.Token.Refresh(token);
        }

        public async Task<RevokeTokenResponse> Revoke(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(AdminKey, httpClient);

            return await api.Token.Revoke();   
        }
    }
}
