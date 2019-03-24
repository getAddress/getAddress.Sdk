using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IInvoiceEmailCcService
    {
        Task<AddInvoiceCCResponse> Add(AddInvoiceCCRequest request,AdminKey adminKey = null);
        Task<GetInvoiceCCResponse> Get(GetInvoiceCCRequest request, AdminKey adminKey = null);
        Task<ListInvoiceCCResponse> List(AdminKey adminKey = null);
        Task<RemoveInvoiceCCResponse> Remove(RemoveInvoiceCCRequest request, AdminKey adminKey = null);
    }
}