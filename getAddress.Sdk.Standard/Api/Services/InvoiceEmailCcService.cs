using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class InvoiceEmailCcService : IInvoiceEmailCcService
    {
        public AdminKey AdminKey { get; }
        public HttpClient HttpClient { get; }

        public InvoiceEmailCcService(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
            HttpClient = httpClient;
        }

        public async Task<AddInvoiceCCResponse> Add(AddInvoiceCCRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey,httpClient))
            {
                return await api.InvoiceCC.Add(request);
            }
        }

        public async Task<RemoveInvoiceCCResponse> Remove(RemoveInvoiceCCRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey,httpClient))
            {
                return await api.InvoiceCC.Remove(request);
            }
        }

        public async Task<ListInvoiceCCResponse> List(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey,httpClient))
            {
                return await api.InvoiceCC.List();
            }
        }

        public async Task<GetInvoiceCCResponse> Get(GetInvoiceCCRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey,httpClient))
            {
                return await api.InvoiceCC.Get(request);
            }
        }
    }
}
