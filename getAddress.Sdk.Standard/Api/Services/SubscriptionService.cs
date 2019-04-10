using getAddress.Sdk.Api.Responses;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class SubscriptionService : ISubscriptionService
    {
        public SubscriptionService(AdminKey adminKey)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }

        public AdminKey AdminKey { get; }

        public async Task<UnsubscribeResponse> Unsubscribe(AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.Subscription.Unsubscribe();
            }
        }

        public async Task<SubscriptionResponse> Subscription(AdminKey adminKey = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey))
            {
                return await api.Subscription.Get();
            }
        }
    }
}
