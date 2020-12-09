using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api.Services
{
    public class SuggestService : ServiceBase, ISuggestService
    {
        public SuggestService(HttpClient httpClient) : base(httpClient)
        {

        }
        public SuggestService() : base(null)
        {

        }

        public SuggestService(ApiKey apiKey, HttpClient httpClient = null) : base(httpClient)
        {
            ApiKey = apiKey ?? throw new System.ArgumentNullException(nameof(apiKey));
        }

        public SuggestService(AccessToken accessToken, HttpClient httpClient = null) : base(accessToken, httpClient)
        {

        }

        public async Task<SuggestResponse> Get(AccessToken accessToken, SuggestRequest request, HttpClient httpClient = null)
        {
            var api = new GetAddesssApi(accessToken, httpClient ?? HttpClient);

            return await api.Suggest.Get(request);
        }

        public async Task<SuggestResponse> Get(SuggestRequest request, ApiKey apiKey = null, HttpClient httpClient = null)
        {
            var api = GetAddesssApi(apiKey, httpClient);

            return await api.Suggest.Get(request);
        }
    }
}
