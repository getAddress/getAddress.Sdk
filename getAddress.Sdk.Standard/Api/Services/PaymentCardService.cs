using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class PaymentCardService : ServiceBase, IPaymentCardService
    {
        public PaymentCardService(HttpClient httpClient) : base(httpClient)
        {

        }
        public PaymentCardService() : base(null)
        {

        }

        public PaymentCardService(AdminKey adminKey, HttpClient httpClient = null) : base(httpClient)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));

        }

        public PaymentCardService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<PaymentCardResponse> List(AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, HttpClient ?? httpClient);

            return await api.PaymentCard.List();
        }

        public async Task<PaymentCardResponse> List(AdminKey adminKey, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.PaymentCard.List();
        }

        public async Task<AddPaymentCardResponse> Add(AddPaymentCardRequest request, AdminKey adminKey, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.PaymentCard.Add(request);
        }

        public async Task<AddPaymentCardResponse> Add(AddPaymentCardRequest request, AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, HttpClient ?? httpClient);

            return await api.PaymentCard.Add(request);
        }
    }
}
