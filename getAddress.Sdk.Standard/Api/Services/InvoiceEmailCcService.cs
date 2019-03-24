using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class InvoiceEmailCcService : IInvoiceEmailCcService
    {
        public AdminKey AdminKey { get; }

        public InvoiceEmailCcService(AdminKey adminKey = null)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }

        public async Task<AddInvoiceCCResponse> Add(AddInvoiceCCRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.InvoiceCC.Add(request);
            }
        }

        public async Task<RemoveInvoiceCCResponse> Remove(RemoveInvoiceCCRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.InvoiceCC.Remove(request);
            }
        }

        public async Task<ListInvoiceCCResponse> List(AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.InvoiceCC.List();
            }
        }

        public async Task<GetInvoiceCCResponse> Get(GetInvoiceCCRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.InvoiceCC.Get(request);
            }
        }
    }
}
