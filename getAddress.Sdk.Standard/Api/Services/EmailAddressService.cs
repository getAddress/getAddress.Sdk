using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class EmailAddressService : ServiceBase, IEmailAddressService
    {
        public EmailAddressService(HttpClient httpClient) : base(httpClient)
        {

        }
        public EmailAddressService() : base(null)
        {

        }
        public EmailAddressService(AdminKey adminKey, HttpClient httpClient = null):base(httpClient)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }
        public EmailAddressService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<EmailAddressResponse> Update(UpdateEmailAddressRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.EmailAddress.Update(request);
        }

        public async Task<EmailAddressResponse> Get(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.EmailAddress.Get();
        }

    }
}
