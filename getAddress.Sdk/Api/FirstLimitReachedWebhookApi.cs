using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class FirstLimitReachedWebhookApi:AdminApiBase
    {
        public const string Path = "webhook/first-limit-reached/";

        internal FirstLimitReachedWebhookApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey,api)
        {

        }
        

         public async  Task<RemoveFirstLimitReachedWebhookResponse> Remove(RemoveFirstLimitReachedWebhookRequest request)
        {
            return await Remove(Api, request, Path, AdminKey);
        }

        public async static Task<RemoveFirstLimitReachedWebhookResponse> Remove(GetAddesssApi api, RemoveFirstLimitReachedWebhookRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (path == null) throw new ArgumentNullException(nameof(path));


            var fullPath = path + request.Id;

            api.SetAuthorizationKey(adminKey);

            var response = await api.Delete(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var message = GetMessage(body);

                return new RemoveFirstLimitReachedWebhookResponse.Success((int)response.StatusCode, response.ReasonPhrase, body,message);
            }

            return new RemoveFirstLimitReachedWebhookResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }


        public async Task<GetFirstLimitReachedWebhookResponse> Get()
        {
            return await Get(Api, Path, AdminKey);
        }

        public async static Task<GetFirstLimitReachedWebhookResponse> Get(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));


            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var webhook = GetFirstLimitWebhook(body);

                return new GetFirstLimitReachedWebhookResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, webhook.Id, webhook.Url);
            }

            return new GetFirstLimitReachedWebhookResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }


        public async Task<AddFirstLimitReachedWebhookResponse> Add(AddFirstLimitReachedWebhookRequest request)
        {
            return await Add(Api, request, Path,AdminKey);
        }

        public async static Task<AddFirstLimitReachedWebhookResponse> Add(GetAddesssApi api, AddFirstLimitReachedWebhookRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Post(path, request);

            var body = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                var messageAndId = GetMessageAndId(body);

                return new AddFirstLimitReachedWebhookResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, messageAndId.Message, messageAndId.Id);
            }

            return new AddFirstLimitReachedWebhookResponse.Failed((int)response.StatusCode, response.ReasonPhrase,body);
        }

        private static FirstLimitWebhook GetFirstLimitWebhook(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new FirstLimitWebhook();

            return JsonConvert.DeserializeObject<FirstLimitWebhook>(body);
        }

        private class FirstLimitWebhook
        {
            public int Id { get; set; }
            public string Url { get; set; }

           
        }


          
    }
}
