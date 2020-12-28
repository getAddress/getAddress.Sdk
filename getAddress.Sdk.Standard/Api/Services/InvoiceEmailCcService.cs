using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{

    public class InvoiceEmailCcService :ServiceBase, IInvoiceEmailCcService
    {
        public InvoiceEmailCcService(HttpClient httpClient) : base(httpClient)
        {

        }
        public InvoiceEmailCcService() : base(null)
        {

        }
        public InvoiceEmailCcService(AdminKey adminKey = null, HttpClient httpClient = null):base(httpClient)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }
        public InvoiceEmailCcService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<AddInvoiceCCResponse> Add(AddInvoiceCCRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.InvoiceCC.Add(request);
        }

        public async Task<AddInvoiceCCResponse> Add(AddInvoiceCCRequest request, AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.InvoiceCC.Add(request);
        }

        public async Task<RemoveInvoiceCCResponse> Remove(RemoveInvoiceCCRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.InvoiceCC.Remove(request);
        }

        public async Task<RemoveInvoiceCCResponse> Remove(RemoveInvoiceCCRequest request, AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.InvoiceCC.Remove(request);
        }

        public async Task<ListInvoiceCCResponse> List(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.InvoiceCC.List();
        }
        public async Task<ListInvoiceCCResponse> List(AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.InvoiceCC.List();
        }

        public async Task<GetInvoiceCCResponse> Get(GetInvoiceCCRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.InvoiceCC.Get(request);
        }

        public async Task<GetInvoiceCCResponse> Get(GetInvoiceCCRequest request, AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.InvoiceCC.Get(request);
        }
    }
}
