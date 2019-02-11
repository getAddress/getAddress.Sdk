using getAddress.Api;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    internal static class WebhookCommands
    {
        internal async static Task<RemoveWebhookResponse> Remove(GetAddesssApi api, RemoveWebhookRequest request, string path, AdminKey adminKey)
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

                return new RemoveWebhookResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, message);
            }

            return new RemoveWebhookResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        internal async static Task<GetWebhookResponse> Get(GetAddesssApi api, string path, AdminKey adminKey, GetWebhookRequest request)
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
                var webhook = GetWebhook(body);

                return new GetWebhookResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, webhook.Id, webhook.Url);
            }

            return new GetWebhookResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        internal async static Task<ListWebhookResponse> List(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var webhooks = ListWebhooks(body);

                return new ListWebhookResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, webhooks);
            }

            return new ListWebhookResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        internal async static Task<AddWebhookResponse> Add(GetAddesssApi api, AddWebhookRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Post(path, request);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var messageAndId = MessageAndId.GetMessageAndId(body);

                return new AddWebhookResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, messageAndId.Message, int.Parse(messageAndId.Id));
            }

            return new AddWebhookResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        internal async static Task<TestWebhookResponse> Test(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Post(path);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var message = GetMessage(body);

                return new TestWebhookResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, message, message);
            }

            return new TestWebhookResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        private static Webhook GetWebhook(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new Webhook();

            return JsonConvert.DeserializeObject<Webhook>(body);
        }

        private static IEnumerable<Webhook> ListWebhooks(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new List<Webhook>();

            var json = JsonConvert.DeserializeObject<JArray>(body);

            var list = new List<Webhook>();

            foreach (dynamic jsonWebhook in json)
            {
                var webhook = new Webhook
                {
                    Id = jsonWebhook.id,
                    Url = jsonWebhook.url
                };

                list.Add(webhook);
            }

            return list;
        }

        private static string GetMessage(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return string.Empty;

            var json = JsonConvert.DeserializeObject<dynamic>(body);

            return json.message ?? json.Message;
        }
    }
}
