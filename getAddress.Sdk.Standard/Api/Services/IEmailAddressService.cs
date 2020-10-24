using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IEmailAddressService
    {
        Task<EmailAddressResponse> Get(AccessToken accessToken, HttpClient httpClient = null);
        Task<EmailAddressResponse> Get(AdminKey adminKey = null, HttpClient httpClient = null);
        Task<EmailAddressResponse> Update(UpdateEmailAddressRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<EmailAddressResponse> Update(UpdateEmailAddressRequest request, AccessToken accessToken, HttpClient httpClient = null);

    }
}