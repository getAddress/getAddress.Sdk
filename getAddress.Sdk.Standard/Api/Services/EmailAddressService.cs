using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class EmailAddressService : IEmailAddressService
    {
        public AdminKey AdminKey { get; }
        public HttpClient HttpClient { get; }

        public EmailAddressService(AdminKey adminKey, HttpClient httpClient = null)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
            HttpClient = httpClient;
        }

        public async Task<EmailAddressResponse> Update(UpdateEmailAddressRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey, HttpClient ?? httpClient))
            {
                return await api.EmailAddress.Update(request);
            }
        }

        public async Task<EmailAddressResponse> Get(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey, HttpClient ?? httpClient))
            {
                return await api.EmailAddress.Get();
            }
        }

    }
}
