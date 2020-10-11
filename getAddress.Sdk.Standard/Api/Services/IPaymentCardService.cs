using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IPaymentCardService
    {
        Task<PaymentCardResponse> List(AccessToken accessToken, HttpClient httpClient = null);

        Task<PaymentCardResponse> List(AdminKey accessToken, HttpClient httpClient = null);
    }
}