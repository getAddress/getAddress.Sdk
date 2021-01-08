using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class PaymentFailedEmailNotificationService : ServiceBase, IPaymentFailedEmailNotificationService
    {
        public PaymentFailedEmailNotificationService(HttpClient httpClient) : base(httpClient)
        {

        }
        public PaymentFailedEmailNotificationService() : base(null)
        {

        }
        public PaymentFailedEmailNotificationService(AdminKey adminKey = null, HttpClient httpClient = null) : base(httpClient)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }
        public PaymentFailedEmailNotificationService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<AddEmailNotificationResponse> Add(AddEmailNotificationRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.PaymentFailedEmailNotification.Add(request);
        }

        public async Task<AddEmailNotificationResponse> Add(AddEmailNotificationRequest request, AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.PaymentFailedEmailNotification.Add(request);
        }

        public async Task<RemoveEmailNotificationResponse> Remove(RemoveEmailNotificationRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.PaymentFailedEmailNotification.Remove(request);
        }

        public async Task<RemoveEmailNotificationResponse> Remove(RemoveEmailNotificationRequest request, AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.PaymentFailedEmailNotification.Remove(request);
        }

        public async Task<ListEmailNotificationResponse> List(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.PaymentFailedEmailNotification.List();
        }
        public async Task<ListEmailNotificationResponse> List(AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.PaymentFailedEmailNotification.List();
        }

        public async Task<GetEmailNotificationResponse> Get(GetEmailNotificationRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.PaymentFailedEmailNotification.Get(request);
        }

        public async Task<GetEmailNotificationResponse> Get(GetEmailNotificationRequest request, AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.PaymentFailedEmailNotification.Get(request);
        }

    }
}
