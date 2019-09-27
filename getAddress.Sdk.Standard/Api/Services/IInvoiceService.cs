using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IInvoiceService
    {
        Task<GetInvoiceResponse> Get(GetInvoiceRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<ListInvoicesResponse> List(AdminKey adminKey = null, HttpClient httpClient = null);

        Task<ListInvoicesResponse> List(ListInvoicesRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
    }
}