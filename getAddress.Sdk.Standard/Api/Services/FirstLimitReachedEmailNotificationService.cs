using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class FirstLimitReachedEmailNotificationService : ServiceBase, IFirstLimitReachedEmailNotificationService
    {
        public FirstLimitReachedEmailNotificationService(HttpClient httpClient) : base(httpClient)
        {

        }
        public FirstLimitReachedEmailNotificationService() : base(null)
        {

        }
        public FirstLimitReachedEmailNotificationService(AdminKey adminKey = null, HttpClient httpClient = null) : base(httpClient)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }
        public FirstLimitReachedEmailNotificationService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<AddEmailNotificationResponse> Add(AddEmailNotificationRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.FirstLimitReachedEmailNotification.Add(request);
        }

        public async Task<AddEmailNotificationResponse> Add(AddEmailNotificationRequest request, AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.FirstLimitReachedEmailNotification.Add(request);
        }

        public async Task<RemoveEmailNotificationResponse> Remove(RemoveEmailNotificationRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.FirstLimitReachedEmailNotification.Remove(request);
        }

        public async Task<RemoveEmailNotificationResponse> Remove(RemoveEmailNotificationRequest request, AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.FirstLimitReachedEmailNotification.Remove(request);
        }

        public async Task<ListEmailNotificationResponse> List(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.FirstLimitReachedEmailNotification.List();
        }
        public async Task<ListEmailNotificationResponse> List(AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.FirstLimitReachedEmailNotification.List();
        }

        public async Task<GetEmailNotificationResponse> Get(GetEmailNotificationRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.FirstLimitReachedEmailNotification.Get(request);
        }

        public async Task<GetEmailNotificationResponse> Get(GetEmailNotificationRequest request, AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.FirstLimitReachedEmailNotification.Get(request);
        }

    }
}
