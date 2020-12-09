using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class InvoiceService : ServiceBase, IInvoiceService
    {
        public InvoiceService(HttpClient httpClient) : base(httpClient)
        {

        }
        public InvoiceService() : base(null)
        {

        }
        public InvoiceService(AdminKey adminKey, HttpClient httpClient = null):base(httpClient)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }
        public InvoiceService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<GetInvoiceResponse> Get(GetInvoiceRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.Invoices.Get(request);
        }

        public async Task<ListInvoicesResponse> List(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);
            
            return await api.Invoices.List();
        }

        public async Task<ListInvoicesResponse> List(AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.Invoices.List();
        }

        public async Task<ListInvoicesResponse> List(ListInvoicesRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.Invoices.List(request);
        }

        public async Task<ListInvoicesResponse> List(ListInvoicesRequest request, AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.Invoices.List(request);
        }


    }
}
