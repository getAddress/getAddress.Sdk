using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class InvoiceService : IInvoiceService
    {

        public InvoiceService(AdminKey adminKey)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }

        public AdminKey AdminKey { get; }

        public async Task<GetInvoiceResponse> Get(GetInvoiceRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.Invoices.Get(request);
            }
        }

        public async Task<ListInvoicesResponse> List(AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.Invoices.List();
            }
        }

    }
}
