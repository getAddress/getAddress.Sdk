using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IPaymentCardService
    {
        Task<PaymentCardResponse> List(AccessToken accessToken, HttpClient httpClient = null);

        Task<PaymentCardResponse> List(AdminKey accessToken, HttpClient httpClient = null);

        Task<AddPaymentCardResponse> Add(AddPaymentCardRequest request, AdminKey adminKey, HttpClient httpClient = null);

        Task<AddPaymentCardResponse> Add(AddPaymentCardRequest request, AccessToken accessToken, HttpClient httpClient = null);

        Task<RemovePaymentCardResponse> Remove(RemovePaymentCardRequest request, AdminKey adminKey, HttpClient httpClient = null);

        Task<RemovePaymentCardResponse> Remove(RemovePaymentCardRequest request, AccessToken accessToken, HttpClient httpClient = null);

        Task<UpdateDefaultPaymentCardResponse> UpdateDefault(UpdateDefaultPaymentCardRequest request, AdminKey adminKey, HttpClient httpClient = null);

        Task<UpdateDefaultPaymentCardResponse> UpdateDefault(UpdateDefaultPaymentCardRequest request, AccessToken accessToken, HttpClient httpClient = null);
        
    }
}