using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api.Services
{
    public interface ITypeaheadService
    {
        Task<TypeaheadResponse> List(AccessToken accessToken, string term, TypeaheadOptions options = null, HttpClient httpClient = null);
        Task<TypeaheadResponse> List(string term, TypeaheadOptions options = null, ApiKey apiKey = null, HttpClient httpClient = null);
    }
}