using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class FirstLimitReachedWebhookApi:AdminApiBase
    {
        public const string Path = "webhook/first-limit-reached/";

        internal FirstLimitReachedWebhookApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey,api)
        {

        }

        public async Task<RemoveFirstLimitReachedWebhookResponse> Remove(int requestId)
        {
            return await Remove(Api, new RemoveFirstLimitReachedWebhookRequest(requestId), Path, AdminKey);
        }

        public async  Task<RemoveFirstLimitReachedWebhookResponse> Remove(RemoveFirstLimitReachedWebhookRequest request)
        {
            return await Remove(Api, request, Path, AdminKey);
        }

        public async Task<RemoveWebhookResponse> Remove(RemoveWebhookRequest request)
        {
            return await Remove(Api, request, Path, AdminKey);
        }

        public async static Task<RemoveFirstLimitReachedWebhookResponse> Remove(GetAddesssApi api, RemoveFirstLimitReachedWebhookRequest request, string path, AdminKey adminKey)
        {
            var result = await Remove(api, new RemoveWebhookRequest(request.Id), path, adminKey);

            return result.FormerResult();
        }

        public async static Task<RemoveWebhookResponse> Remove(GetAddesssApi api, RemoveWebhookRequest request, string path, AdminKey adminKey)
        {
            return await WebhookCommands.Remove(api, request, path, adminKey);
        }

        public async Task<GetFirstLimitReachedWebhookResponse> Get(int requestId)
        {
            return await Get(Api, Path, AdminKey, new GetFirstLimitReachedRequest(requestId));
        }

        public async Task<GetFirstLimitReachedWebhookResponse> Get(GetFirstLimitReachedRequest request)
        {
            return await Get(Api, Path, AdminKey,request);
        }

        public async Task<GetWebhookResponse> Get(GetWebhookRequest request)
        {
            return await Get(Api, Path, AdminKey, request);
        }


        public async static Task<GetFirstLimitReachedWebhookResponse> Get(GetAddesssApi api, string path, AdminKey adminKey, GetFirstLimitReachedRequest request)
        {
            var result = await Get(api, path, adminKey, new GetWebhookRequest(request.Id));

            return result.FormerResult();
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


        public async Task<AddFirstLimitReachedWebhookResponse> Add(string url)
        {
            return await Add(Api, new AddFirstLimitReachedWebhookRequest(url), Path, AdminKey);
        }

        public async Task<AddFirstLimitReachedWebhookResponse> Add(AddFirstLimitReachedWebhookRequest request)
        {
            return await Add(Api, request, Path,AdminKey);
        }

        public async Task<AddWebhookResponse> Add(AddWebhookRequest request)
        {
            return await Add(Api, request, Path, AdminKey);
        }

        public async static Task<AddFirstLimitReachedWebhookResponse> Add(GetAddesssApi api, AddFirstLimitReachedWebhookRequest request, string path, AdminKey adminKey)
        {
            var result = await Add(api, new AddWebhookRequest(request.Url), path, adminKey);

            return result.FormerResult();
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
