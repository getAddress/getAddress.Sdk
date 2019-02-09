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

        public async  Task<RemoveSecondLimitReachedWebhookResponse> Remove(RemoveSecondLimitReachedWebhookRequest request)
        {
            return await Remove(Api, request, Path, AdminKey);
        }

        public async static Task<RemoveSecondLimitReachedWebhookResponse> Remove(GetAddesssApi api, RemoveSecondLimitReachedWebhookRequest request, string path, AdminKey adminKey)
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

                return new RemoveSecondLimitReachedWebhookResponse.Success((int)response.StatusCode, response.ReasonPhrase, body,message);
            }

            return new RemoveSecondLimitReachedWebhookResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }


        public async Task<TestSecondLimitReachedWebhookResponse> Test()
        {
            return await Test(Api, $"{Path}test", AdminKey);
        }

        public async static Task<TestSecondLimitReachedWebhookResponse> Test(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Post(path);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var message = GetMessage(body);

                return new TestSecondLimitReachedWebhookResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, message, message);
            }

            return new TestSecondLimitReachedWebhookResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        public async Task<GetSecondLimitReachedWebhookResponse> Get(GetSecondLimitReachedRequest request)
        {
            return await Get(Api, Path, AdminKey,request);
        }

       

        public async static Task<GetSecondLimitReachedWebhookResponse> Get(GetAddesssApi api, string path, AdminKey adminKey, GetSecondLimitReachedRequest request)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));
            if (request == null) throw new ArgumentNullException(nameof(request));


            var fullPath = path + request.Id;

            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var webhook = GetSecondLimitWebhook(body);

                return new GetSecondLimitReachedWebhookResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, webhook.Id, webhook.Url);
            }

            return new GetSecondLimitReachedWebhookResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        public async Task<ListSecondLimitReachedWebhookResponse> List()
        {
            return await List(Api, Path, AdminKey);
        }

         public async static Task<ListSecondLimitReachedWebhookResponse> List(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));


            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(Path);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var webhooks = ListSecondLimitReachedWebhooks(body);

                return new ListSecondLimitReachedWebhookResponse.Success((int)response.StatusCode, response.ReasonPhrase, body,webhooks);
            }

            return new ListSecondLimitReachedWebhookResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }


        public async Task<AddSecondLimitReachedWebhookResponse> Add(AddSecondLimitReachedWebhookRequest request)
        {
            return await Add(Api, request, Path,AdminKey);
        }

        public async static Task<AddSecondLimitReachedWebhookResponse> Add(GetAddesssApi api, AddSecondLimitReachedWebhookRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Post(path, request);

            var body = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                var messageAndId = GetMessageAndId(body);

                return new AddSecondLimitReachedWebhookResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, messageAndId.Message, messageAndId.Id);
            }

            return new AddSecondLimitReachedWebhookResponse.Failed((int)response.StatusCode, response.ReasonPhrase,body);
        }

        private static SecondLimitReachedWebhook GetSecondLimitWebhook(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new SecondLimitReachedWebhook();

            return JsonConvert.DeserializeObject<SecondLimitReachedWebhook>(body);
        }

      private static IEnumerable<SecondLimitReachedWebhook> ListSecondLimitReachedWebhooks(string body)
      {
         if (string.IsNullOrWhiteSpace(body)) return new List<SecondLimitReachedWebhook>();
         
         var json = JsonConvert.DeserializeObject<JArray>(body);
         
         var list = new List<SecondLimitReachedWebhook>();
         
         foreach (dynamic jsonWebhook in json)
         {
             var webhook =  new SecondLimitReachedWebhook
             {
                 Id = jsonWebhook.id,
                 Url = jsonWebhook.url
             };
         
             list.Add(webhook);
         }
         
         return list;
       }
    }
}
