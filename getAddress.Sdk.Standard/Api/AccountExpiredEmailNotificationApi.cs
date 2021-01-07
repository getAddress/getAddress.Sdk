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
    public class AccountExpiredEmailNotificationApi : AdminApiBase
    {
        public const string Path = "email-notification/account-expired/";

        internal AccountExpiredEmailNotificationApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey, api)
        {

        }

        public async  Task<RemoveEmailNotificationResponse> Remove(RemoveEmailNotificationRequest request)
        {
            return await Remove(this.Api, request, Path, AdminKey);
        }

        public async static Task<RemoveEmailNotificationResponse> Remove(GetAddesssApi api, RemoveEmailNotificationRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (path == null) throw new ArgumentNullException(nameof(path));

            var fullPath = path + request.Id;

            api.SetAuthorizationKey(adminKey);

            var response = await api.Delete(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, RemoveEmailNotificationResponse> success = (statusCode, phrase, json) =>
            {
                var message = GetMessage(json);

                return new RemoveEmailNotificationResponse.Success(statusCode, phrase, json, message);
            };

            Func<string, string, RemoveEmailNotificationResponse> tokenExpired = (rp, b) => { return new RemoveEmailNotificationResponse.TokenExpired(rp, b); };
            Func<string, string, double, RemoveEmailNotificationResponse> limitReached = (rp, b, r) => { return new RemoveEmailNotificationResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, RemoveEmailNotificationResponse> failed = (sc, rp, b) => { return new RemoveEmailNotificationResponse.Failed(sc, rp, b); };
            Func<string, string, RemoveEmailNotificationResponse> forbidden = (rp, b) => { return new RemoveEmailNotificationResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden
                );
        }


        public async Task<ListEmailNotificationResponse> List()
        {
            return await List(Api, Path, AdminKey);
        }
        public async static Task<ListEmailNotificationResponse> List(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));

            api.SetAuthorizationKey(adminKey);

            var response = await api.HttpGet(path);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, ListEmailNotificationResponse> success = (statusCode, phrase, json) =>
            {
                var list = GetEmailNotifications(json);

                return new ListEmailNotificationResponse.Success(statusCode, phrase, json, list);
            };

            Func<string, string, ListEmailNotificationResponse> tokenExpired = (rp, b) => { return new ListEmailNotificationResponse.TokenExpired(rp, b); };
            Func<string, string, double, ListEmailNotificationResponse> limitReached = (rp, b, r) => { return new ListEmailNotificationResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, ListEmailNotificationResponse> failed = (sc, rp, b) => { return new ListEmailNotificationResponse.Failed(sc, rp, b); };
            Func<string, string, ListEmailNotificationResponse> forbidden = (rp, b) => { return new ListEmailNotificationResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);
        }

        private static IEnumerable<EmailNotification> GetEmailNotifications(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new List<EmailNotification>();

            var json = JsonConvert.DeserializeObject<JArray>(body);

            var list = new List<EmailNotification>();

            foreach (var token in json)
            {
                var emailNotification = token.ToObject<EmailNotification>();

                list.Add(emailNotification);
            }

            return list;
        }

        public async  Task<AddEmailNotificationResponse> Add(AddEmailNotificationRequest request)
        {
            return await Add(this.Api, request, Path, AdminKey);
        }

        public async static Task<AddEmailNotificationResponse> Add(GetAddesssApi api, AddEmailNotificationRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Post(path, request);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, AddEmailNotificationResponse> success = (statusCode, phrase, json) =>
            {
                var messageAndId = MessageAndId.GetMessageAndId(json);

                var id = long.Parse(messageAndId.Id);

                return new AddEmailNotificationResponse.Success(statusCode, phrase, json, messageAndId.Message, id);
            };

            Func<string, string, AddEmailNotificationResponse> tokenExpired = (rp, b) => { return new AddEmailNotificationResponse.TokenExpired(rp, b); };
            Func<string, string, double, AddEmailNotificationResponse> limitReached = (rp, b, r) => { return new AddEmailNotificationResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, AddEmailNotificationResponse> failed = (sc, rp, b) => { return new AddEmailNotificationResponse.Failed(sc, rp, b); };
            Func<string, string, AddEmailNotificationResponse> forbidden = (rp, b) => { return new AddEmailNotificationResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);

        }

        public async  Task<GetEmailNotificationResponse> Get(GetEmailNotificationRequest request)
        {
            return await Get(this.Api, Path, AdminKey, request);
        }

        public async static Task<GetEmailNotificationResponse> Get(GetAddesssApi api, string path,
           AdminKey adminKey, GetEmailNotificationRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));

            var fullPath = $"{path}{request.Id}";

            api.SetAuthorizationKey(adminKey);

            var response = await api.HttpGet(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, GetEmailNotificationResponse> success = (statusCode, phrase, json) =>
            {
                var entity = EmailNotification.FromJson(json);

                return new GetEmailNotificationResponse.Success(statusCode, phrase, json, entity);
            };

            Func<string, string, GetEmailNotificationResponse> tokenExpired = (rp, b) => { return new GetEmailNotificationResponse.TokenExpired(rp, b); };
            Func<string, string, double, GetEmailNotificationResponse> limitReached = (rp, b, r) => { return new GetEmailNotificationResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, GetEmailNotificationResponse> failed = (sc, rp, b) => { return new GetEmailNotificationResponse.Failed(sc, rp, b); };
            Func<string, string, GetEmailNotificationResponse> forbidden = (rp, b) => { return new GetEmailNotificationResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);
        }



    }
}
