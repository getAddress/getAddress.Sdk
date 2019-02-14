using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class PaymentFailedWebhookApi:AdminApiBase
    {
        public const string Path = "webhook/payment-failed/";

        internal PaymentFailedWebhookApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey,api)
        {

        }

        public async Task<RemoveWebhookResponse> Remove(RemoveWebhookRequest request)
        {
            return await Remove(Api, request, Path, AdminKey);
        }

        public async static Task<RemoveWebhookResponse> Remove(GetAddesssApi api, RemoveWebhookRequest request, string path, AdminKey adminKey)
        {
            return await WebhookCommands.Remove(api, request, path, adminKey);
        }

        public async Task<GetWebhookResponse> Get(GetWebhookRequest request)
        {
            return await Get(Api, Path, AdminKey, request);
        }

        public async static Task<GetWebhookResponse> Get(GetAddesssApi api, string path, AdminKey adminKey, GetWebhookRequest request)
        {
            return await WebhookCommands.Get(api, path, adminKey, request);
        }

        public async Task<ListWebhookResponse> List()
        {
            return await List(Api, Path, AdminKey);
        }

        public async static Task<ListWebhookResponse> List(GetAddesssApi api, string path, AdminKey adminKey)
        {
            return await WebhookCommands.List(api, path, adminKey);
        }

        public async Task<AddWebhookResponse> Add(AddWebhookRequest request)
        {
            return await Add(Api, request, Path, AdminKey);
        }

        public async static Task<AddWebhookResponse> Add(GetAddesssApi api, AddWebhookRequest request, string path, AdminKey adminKey)
        {
            return await WebhookCommands.Add(api, request, path, adminKey);
        }

        public async Task<TestWebhookResponse> Test()
        {
            return await Test(Api, $"{Path}test", AdminKey);
        }

        public async static Task<TestWebhookResponse> Test(GetAddesssApi api, string path, AdminKey adminKey)
        {
            return await WebhookCommands.Test(api, path, adminKey);
        }
    }
}
