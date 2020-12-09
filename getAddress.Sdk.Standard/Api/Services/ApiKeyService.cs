﻿using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class ApiKeyService : ServiceBase, IApiKeyService
    {
        public ApiKeyService(HttpClient httpClient) : base(httpClient)
        {

        }
        public ApiKeyService() : base(null)
        {

        }
        public ApiKeyService(AdminKey adminKey,HttpClient httpClient = null):base(httpClient)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
        }
        public ApiKeyService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<ApiKeyResponse> Update(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.ApiKeyApi.Update();
        }
        public async Task<ApiKeyResponse> Update(AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.ApiKeyApi.Update();
        }

        public async Task<ApiKeyResponse> Get(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(adminKey, httpClient);

            return await api.ApiKeyApi.Get();
        }
        public async Task<ApiKeyResponse> Get(AccessToken accessToken, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.ApiKeyApi.Get();
        }

    }
}
