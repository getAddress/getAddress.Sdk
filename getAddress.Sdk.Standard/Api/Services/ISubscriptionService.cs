using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface ISubscriptionService
    {
        Task<UnsubscribeResponse> Unsubscribe(AdminKey adminKey = null, HttpClient httpClient = null);

        Task<SubscriptionResponse> Subscription(AdminKey adminKey = null, HttpClient httpClient = null);

        Task<SubscriptionV2Response> Get(AccessToken accessToken, HttpClient httpClient = null);
    }
}