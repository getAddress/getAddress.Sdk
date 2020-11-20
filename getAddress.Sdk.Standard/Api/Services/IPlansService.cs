using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public interface IPlansService
    {
        Task<PlansResponse> Get(AdminKey adminKey, HttpClient httpClient = null);

        Task<PlansResponse> Get(AccessToken accessToken, HttpClient httpClient = null);
    }
}