using getAddress.Api;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class SecondLimitReachedWebhookApi:AdminApiBase
    {
        public const string Path = "webhook/second-limit-reached/";

        internal SecondLimitReachedWebhookApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey,api)
        {

        }

        public async Task<RemoveWebhookResponse> Remove(int requestId)
        {
            return await Remove(Api, new RemoveWebhookRequest(requestId), Path, AdminKey);
        }

        public async Task<RemoveWebhookResponse> Remove(RemoveWebhookRequest request)
        {
            return await Remove(Api, request, Path, AdminKey);
        }

        public async  Task<RemoveSecondLimitReachedWebhookResponse> Remove(RemoveSecondLimitReachedWebhookRequest request)
        {
            return await Remove(Api, request, Path, AdminKey);
        }

        public async static Task<RemoveSecondLimitReachedWebhookResponse> Remove(GetAddesssApi api, RemoveSecondLimitReachedWebhookRequest request, string path, AdminKey adminKey)
        {
            var result = await Remove(api, new RemoveWebhookRequest(request.Id), path, adminKey);

            return result.FormerResult2();
        }

        public async static Task<RemoveWebhookResponse> Remove(GetAddesssApi api, RemoveWebhookRequest request, string path, AdminKey adminKey)
        {
            return await WebhookCommands.Remove(api, request, path, adminKey);
        }

        public async Task<TestWebhookResponse> Test()
        {
            return await Test(Api, $"{Path}test", AdminKey);
        }


        public async static Task<TestWebhookResponse> Test(GetAddesssApi api, string path, AdminKey adminKey)
        {
            return await WebhookCommands.Test(api, path, adminKey);
        }

        public async Task<GetSecondLimitReachedWebhookResponse> Get(GetSecondLimitReachedRequest request)
        {
            return await Get(Api, Path, AdminKey,request);
        }

        public async Task<GetWebhookResponse> Get(GetWebhookRequest request)
        {
            return await Get(Api, Path, AdminKey, request);
        }

        public async static Task<GetSecondLimitReachedWebhookResponse> Get(GetAddesssApi api, string path, AdminKey adminKey, GetSecondLimitReachedRequest request)
        {
            var result = await Get(api, path, adminKey, new GetWebhookRequest(request.Id));

            return result.FormerResult2();
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

        public async Task<AddSecondLimitReachedWebhookResponse> Add(AddSecondLimitReachedWebhookRequest request)
        {
            return await Add(Api, request, Path,AdminKey);
        }

        public async static Task<AddSecondLimitReachedWebhookResponse> Add(GetAddesssApi api, AddSecondLimitReachedWebhookRequest request, string path, AdminKey adminKey)
        {
            var result = await Add(api, new AddWebhookRequest(request.Url), path, adminKey);

            return result.FormerResult2();
        }


        public async static Task<AddWebhookResponse> Add(GetAddesssApi api, AddWebhookRequest request, string path, AdminKey adminKey)
        {
            return await WebhookCommands.Add(api, request, path, adminKey);
        }

    }
}
