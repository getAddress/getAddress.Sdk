using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class EmailAddressService : IEmailAddressService
    {
        public AdminKey AdminKey { get; }

        public EmailAddressService(AdminKey adminKey)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }

        public async Task<EmailAddressResponse> Update(UpdateEmailAddressRequest request, AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.EmailAddress.Update(request);
            }
        }

        public async Task<EmailAddressResponse> Get(AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.EmailAddress.Get();
            }
        }

    }
}
