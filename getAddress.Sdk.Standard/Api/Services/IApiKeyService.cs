using System.Threading.Tasks;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IApiKeyService
    {
        Task<ApiKeyResponse> Get(AdminKey adminKey = null);
        Task<ApiKeyResponse> Update(AdminKey adminKey = null);
    }
}