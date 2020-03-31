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

            Func<int, string, string, RemoveWebhookResponse> success = (statusCode, phrase, json) =>
            {
                var message = GetMessage(json);

                return new RemoveWebhookResponse.Success(statusCode, phrase, json, message);
            };

            Func<string, string, RemoveWebhookResponse> tokenExpired = (rp, b) => { return new RemoveWebhookResponse.TokenExpired(rp, b); };
            Func<string, string, double, RemoveWebhookResponse> limitReached = (rp, b, r) => { return new RemoveWebhookResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, RemoveWebhookResponse> failed = (sc, rp, b) => { return new RemoveWebhookResponse.Failed(sc, rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed);
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

            Func<int, string, string, GetWebhookResponse> success = (statusCode, phrase, json) =>
            {
                var webhook = GetWebhook(json);

                return new GetWebhookResponse.Success(statusCode,phrase, json, webhook.Id, webhook.Url);
            };

            Func<string, string, GetWebhookResponse> tokenExpired = (rp, b) => { return new GetWebhookResponse.TokenExpired(rp, b); };
            Func<string, string, double, GetWebhookResponse> limitReached = (rp, b, r) => { return new GetWebhookResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, GetWebhookResponse> failed = (sc, rp, b) => { return new GetWebhookResponse.Failed(sc, rp, b); };

            return response.GetResponse( body,
                success,
                tokenExpired,
                limitReached,
                failed);

        }

        internal async static Task<ListWebhookResponse> List(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, ListWebhookResponse> success = (statusCode, phrase, json) =>
            {
                var webhooks = ListWebhooks(json);

                return new ListWebhookResponse.Success(statusCode, phrase, json, webhooks);
            };

            Func<string, string, ListWebhookResponse> tokenExpired = (rp, b) => { return new ListWebhookResponse.TokenExpired(rp, b); };
            Func<string, string, double, ListWebhookResponse> limitReached = (rp, b, r) => { return new ListWebhookResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, ListWebhookResponse> failed = (sc, rp, b) => { return new ListWebhookResponse.Failed(sc, rp, b); };

            return response.GetResponse( body,
                success,
                tokenExpired,
                limitReached,
                failed);

        }

        internal async static Task<AddWebhookResponse> Add(GetAddesssApi api, AddWebhookRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Post(path, request);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, AddWebhookResponse> success = (statusCode, phrase, json) =>
            {
                var messageAndId = MessageAndId.GetMessageAndId(json);

                return new AddWebhookResponse.Success(statusCode, phrase, json, messageAndId.Message, int.Parse(messageAndId.Id));
            };

            Func<string, string, AddWebhookResponse> tokenExpired = (rp, b) => { return new AddWebhookResponse.TokenExpired(rp, b); };
            Func<string, string, double, AddWebhookResponse> limitReached = (rp, b, r) => { return new AddWebhookResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, AddWebhookResponse> failed = (sc, rp, b) => { return new AddWebhookResponse.Failed(sc, rp, b); };

            return response.GetResponse( body,
                success,
                tokenExpired,
                limitReached,
                failed);

        }

        internal async static Task<TestWebhookResponse> Test(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Post(path);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, TestWebhookResponse> success = (statusCode, phrase, json) =>
            {
                var message = GetMessage(json);

                return new TestWebhookResponse.Success(statusCode,phrase, json, message, message);
            };

            Func<string, string, TestWebhookResponse> tokenExpired = (rp, b) => { return new TestWebhookResponse.TokenExpired(rp, b); };
            Func<string, string, double, TestWebhookResponse> limitReached = (rp, b, r) => { return new TestWebhookResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, TestWebhookResponse> failed = (sc, rp, b) => { return new TestWebhookResponse.Failed(sc, rp, b); };

            return response.GetResponse( body,
                success,
                tokenExpired,
                limitReached,
                failed);
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
