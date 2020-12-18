using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IWebhookService
    {
        Task<AddWebhookResponse> Add(AddWebhookRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<AddWebhookResponse> Add(AddWebhookRequest request, AccessToken accessToken, HttpClient httpClient = null);

        Task<GetWebhookResponse> Get(GetWebhookRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<GetWebhookResponse> Get(GetWebhookRequest request, AccessToken accessToken, HttpClient httpClient = null);
        Task<ListWebhookResponse> List(AdminKey adminKey = null, HttpClient httpClient = null);
        Task<ListWebhookResponse> List(AccessToken accessToken, HttpClient httpClient = null);
        Task<RemoveWebhookResponse> Remove(RemoveWebhookRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<RemoveWebhookResponse> Remove(RemoveWebhookRequest request,AccessToken accessToken, HttpClient httpClient = null);
        Task<TestWebhookResponse> Test(AdminKey adminKey = null, HttpClient httpClient = null);
        Task<TestWebhookResponse> Test(AccessToken accessToken, HttpClient httpClient = null);
    }

    public interface IExpiredWebhookService: IWebhookService
    {
    }
    public interface IFirstLimitReachedWebhookService : IWebhookService
    {
    }
    public interface ISecondLimitReachedWebhookService : IWebhookService
    {
    }
    public interface IPaymentFailedWebhookService : IWebhookService
    {
    }
    public interface ITrackWebhookService : IWebhookService
    {
    }

}