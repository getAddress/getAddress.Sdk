using System.Threading.Tasks;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface ISubscriptionService
    {
        Task<UnsubscribeResponse> Unsubscribe(AdminKey adminKey = null);

        Task<SubscriptionResponse> Subscription(AdminKey adminKey = null);
    }
}