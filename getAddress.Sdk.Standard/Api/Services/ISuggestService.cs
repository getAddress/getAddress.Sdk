using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api.Services
{
    public interface ISuggestService
    {
        Task<SuggestResponse> Get(AccessToken accessToken, SuggestRequest request, HttpClient httpClient = null);
        Task<SuggestResponse> Get(SuggestRequest request, ApiKey apiKey = null, HttpClient httpClient = null);
    }
}