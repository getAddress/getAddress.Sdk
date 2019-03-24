using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IEmailAddressService
    {
        Task<EmailAddressResponse> Get(AdminKey adminKey = null);
        Task<EmailAddressResponse> Update(UpdateEmailAddressRequest request, AdminKey adminKey = null);
    }
}