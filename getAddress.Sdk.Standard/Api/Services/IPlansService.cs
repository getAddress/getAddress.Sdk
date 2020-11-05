using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public interface IPlansService
    {
        Task<PlansResponse> Get(HttpClient httpClient = null);
    }
}