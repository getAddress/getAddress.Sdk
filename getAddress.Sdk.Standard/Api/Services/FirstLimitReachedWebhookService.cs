﻿using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class FirstLimitReachedWebhookService :ServiceBase, IFirstLimitReachedWebhookService
    {
        public FirstLimitReachedWebhookService(HttpClient httpClient) : base(httpClient)
        {

        }
        public FirstLimitReachedWebhookService() : base(null)
        {

        }
        public FirstLimitReachedWebhookService(AdminKey adminKey, HttpClient httpClient = null):base(httpClient)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }
        public FirstLimitReachedWebhookService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<AddWebhookResponse> Add(AddWebhookRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.FirstLimitReachedWebhook.Add(request);
        }

        public async Task<AddWebhookResponse> Add(AddWebhookRequest request, AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.FirstLimitReachedWebhook.Add(request);
        }

        public async Task<RemoveWebhookResponse> Remove(RemoveWebhookRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.FirstLimitReachedWebhook.Remove(request);
        }

        public async Task<RemoveWebhookResponse> Remove(RemoveWebhookRequest request, AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.FirstLimitReachedWebhook.Remove(request);
        }

        public async Task<ListWebhookResponse> List(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.FirstLimitReachedWebhook.List();
        }

        public async Task<ListWebhookResponse> List(AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.FirstLimitReachedWebhook.List();
        }

        public async Task<GetWebhookResponse> Get(GetWebhookRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.FirstLimitReachedWebhook.Get(request);
        }

        public async Task<GetWebhookResponse> Get(GetWebhookRequest request, AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.FirstLimitReachedWebhook.Get(request);
        }

        public async Task<TestWebhookResponse> Test(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.FirstLimitReachedWebhook.Test();
        }

        public async Task<TestWebhookResponse> Test(AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.FirstLimitReachedWebhook.Test();
        }

        
    }
}
