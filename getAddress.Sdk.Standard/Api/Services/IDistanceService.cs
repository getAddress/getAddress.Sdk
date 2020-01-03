using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IDistanceService
    {
        ApiKey ApiKey { get; }

        Task<DistanceResponse> Get(DistanceRequest request, ApiKey apiKey = null, HttpClient httpClient = null);
    }
}