using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api.Services
{
    public interface IGetService
    {
        Task<GetResponse> Get(string id, ApiKey apiKey = null, HttpClient httpClient = null);
        Task<GetResponse> Get(Suggestion suggestion, ApiKey apiKey = null, HttpClient httpClient = null);
    }
}