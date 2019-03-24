using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IExpiredEmailCcService
    {
        Task<AddExpiredCCResponse> Add(AddExpiredCCRequest request, AdminKey adminKey = null);
        Task<GetExpiredCCResponse> Get(GetExpiredCCRequest request, AdminKey adminKey = null);
        Task<ListExpiredCCResponse> List(AdminKey adminKey = null);
        Task<RemoveExpiredCCResponse> Remove(RemoveExpiredCCRequest request, AdminKey adminKey = null);
    }
}