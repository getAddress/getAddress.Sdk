using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class SecondLimitReachedEmailNotificationService : ServiceBase, ISecondLimitReachedEmailNotificationService
    {
        public SecondLimitReachedEmailNotificationService(HttpClient httpClient) : base(httpClient)
        {

        }
        public SecondLimitReachedEmailNotificationService() : base(null)
        {

        }
        public SecondLimitReachedEmailNotificationService(AdminKey adminKey = null, HttpClient httpClient = null) : base(httpClient)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }
        public SecondLimitReachedEmailNotificationService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<AddEmailNotificationResponse> Add(AddEmailNotificationRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.SecondLimitReachedEmailNotification.Add(request);
        }

        public async Task<AddEmailNotificationResponse> Add(AddEmailNotificationRequest request, AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.SecondLimitReachedEmailNotification.Add(request);
        }

        public async Task<RemoveEmailNotificationResponse> Remove(RemoveEmailNotificationRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.SecondLimitReachedEmailNotification.Remove(request);
        }

        public async Task<RemoveEmailNotificationResponse> Remove(RemoveEmailNotificationRequest request, AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.SecondLimitReachedEmailNotification.Remove(request);
        }

        public async Task<ListEmailNotificationResponse> List(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.SecondLimitReachedEmailNotification.List();
        }
        public async Task<ListEmailNotificationResponse> List(AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.SecondLimitReachedEmailNotification.List();
        }

        public async Task<GetEmailNotificationResponse> Get(GetEmailNotificationRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.SecondLimitReachedEmailNotification.Get(request);
        }

        public async Task<GetEmailNotificationResponse> Get(GetEmailNotificationRequest request, AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.SecondLimitReachedEmailNotification.Get(request);
        }

    }
}
