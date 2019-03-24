using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IWebhookService
    {
        Task<AddWebhookResponse> Add(AddWebhookRequest request, AdminKey adminKey = null);
        Task<GetWebhookResponse> Get(GetWebhookRequest request, AdminKey adminKey = null);
        Task<ListWebhookResponse> List(AdminKey adminKey = null);
        Task<RemoveWebhookResponse> Remove(RemoveWebhookRequest request, AdminKey adminKey = null);
        Task<TestWebhookResponse> Test(AdminKey adminKey = null);
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

}