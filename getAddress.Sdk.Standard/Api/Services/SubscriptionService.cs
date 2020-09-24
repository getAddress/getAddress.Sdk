using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class SubscriptionService : ServiceBase, ISubscriptionService
    {
        public SubscriptionService(HttpClient httpClient) : base(httpClient)
        {

        }
        public SubscriptionService() : base(null)
        {

        }

        public SubscriptionService(AdminKey adminKey, HttpClient httpClient = null):base(httpClient)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
           
        }

        public SubscriptionService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<UnsubscribeResponse> Unsubscribe(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.Subscription.Unsubscribe();
        }

        public async Task<UnsubscribeResponse> Unsubscribe(AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, HttpClient ?? httpClient);

            return await api.Subscription.Unsubscribe();
        }

        public async Task<SubscriptionUpdatedResponse> Update(UpdateSubscriptionRequest request, AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, HttpClient ?? httpClient);

            return await api.Subscription.Update(request);
        }

        public async Task<SubscriptionUpdatedResponse> Update(UpdateSubscriptionRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.Subscription.Update(request);
        }

        public async Task<SubscriptionResponse> Subscription(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.Subscription.Get();
        }

        public async Task<SubscriptionV2Response> Get(AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, HttpClient ?? httpClient);

            return await api.Subscription.GetV2();
        }
    }
}
