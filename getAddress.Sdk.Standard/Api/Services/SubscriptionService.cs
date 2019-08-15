using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class SubscriptionService : ISubscriptionService
    {
        public SubscriptionService(AdminKey adminKey, HttpClient httpClient = null)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
            HttpClient = httpClient;
        }

        public AdminKey AdminKey { get; }
        public HttpClient HttpClient { get; }

        public async Task<UnsubscribeResponse> Unsubscribe(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey,httpClient))
            {
                return await api.Subscription.Unsubscribe();
            }
        }

        public async Task<SubscriptionResponse> Subscription(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey,httpClient))
            {
                return await api.Subscription.Get();
            }
        }
    }
}
