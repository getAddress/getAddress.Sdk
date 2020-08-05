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
    public class PermissionApi: AdminApiBase
    {
        public const string Path = "permission/";

        internal PermissionApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey, api)
        {

        }

        public async Task<PermissionResponse> Get(GetPermissionRequest request)
        {
            return await Get(request, Api, Path, AdminKey);
        }

        public async static Task<PermissionResponse> Get(GetPermissionRequest request, GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));

            api.SetAuthorizationKey(adminKey);

            var fullPath = path + $"{request.EmailAddress}/";

            var response = await api.HttpGet(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, PermissionResponse> success = (statusCode, phrase, json) =>
            {
                var permission = GetPermission(json);

                return new PermissionResponse.Success(statusCode, phrase, json, permission);
            };

            Func<string, string, PermissionResponse> tokenExpired = (rp, b) => { return new PermissionResponse.TokenExpired(rp, b); };
            Func<string, string, double, PermissionResponse> limitReached = (rp, b, r) => { return new PermissionResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, PermissionResponse> failed = (sc, rp, b) => { return new PermissionResponse.Failed(sc, rp, b); };
            Func<string, string, PermissionResponse> forbidden = (rp, b) => { return new PermissionResponse.Forbidden(rp, b); };


            return response.GetResponse( body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);
        }

        public async Task<ListPermissionResponse> List()
        {
            return await List(Api, Path, AdminKey);
        }

        public async static Task<ListPermissionResponse> List(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));

            api.SetAuthorizationKey(adminKey);

            var response = await api.HttpGet(path);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, ListPermissionResponse> success = (statusCode, phrase, json) =>
            {
                var permissions = GetPermissions(json);

                return new ListPermissionResponse.Success(statusCode, phrase, json, permissions);
            };

            Func<string, string, ListPermissionResponse> tokenExpired = (rp, b) => { return new ListPermissionResponse.TokenExpired(rp, b); };
            Func<string, string, double, ListPermissionResponse> limitReached = (rp, b, r) => { return new ListPermissionResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, ListPermissionResponse> failed = (sc, rp, b) => { return new ListPermissionResponse.Failed(sc, rp, b); };

            Func<string, string, ListPermissionResponse> forbidden = (rp, b) => { return new ListPermissionResponse.Forbidden(rp, b); };


            return response.GetResponse( body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);

        }

        public async Task<UpdatePermissionResponse> Update(UpdatePermissionRequest request)
        {
            return await Update(Api, request, Path, AdminKey);
        }

        public async static Task<UpdatePermissionResponse> Update(GetAddesssApi api, UpdatePermissionRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Put(path, request);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, UpdatePermissionResponse> success = (statusCode, phrase, json) =>
            {
                var message = MessageResponse.GetMessageResponse(json);

                return new UpdatePermissionResponse.Success(statusCode, phrase, json, message.Message);
            };

            Func<string, string, UpdatePermissionResponse> tokenExpired = (rp, b) => { return new UpdatePermissionResponse.TokenExpired(rp, b); };
            Func<string, string, double, UpdatePermissionResponse> limitReached = (rp, b, r) => { return new UpdatePermissionResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, UpdatePermissionResponse> failed = (sc, rp, b) => { return new UpdatePermissionResponse.Failed(sc, rp, b); };
            Func<string, string, UpdatePermissionResponse> forbidden = (rp, b) => { return new UpdatePermissionResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);

        }

        public async Task<AddPermissionResponse> Add(AddPermissionRequest request)
        {
            return await Add(Api, request, Path, AdminKey);
        }

        public async static Task<AddPermissionResponse> Add(GetAddesssApi api, AddPermissionRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Post(path, request);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, AddPermissionResponse> success = (statusCode, phrase, json) =>
            {
                var message = MessageResponse.GetMessageResponse(json);

                return new AddPermissionResponse.Success(statusCode, phrase, json, message.Message);
            };

            Func<string, string, AddPermissionResponse> tokenExpired = (rp, b) => { return new AddPermissionResponse.TokenExpired(rp, b); };
            Func<string, string, double, AddPermissionResponse> limitReached = (rp, b, r) => { return new AddPermissionResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, AddPermissionResponse> failed = (sc, rp, b) => { return new AddPermissionResponse.Failed(sc, rp, b); };
            Func<string, string, AddPermissionResponse> forbidden = (rp, b) => { return new AddPermissionResponse.Forbidden(rp, b); };


            return response.GetResponse( body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);

        }

        public async Task<RemovePermissionResponse> Remove(RemovePermissionRequest request)
        {
            return await Remove(Api, request, Path, AdminKey);
        }

        public async static Task<RemovePermissionResponse> Remove(GetAddesssApi api, RemovePermissionRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (path == null) throw new ArgumentNullException(nameof(path));

            api.SetAuthorizationKey(adminKey);

            var fullPath = path + $"{request.EmailAddress}/";

            var response = await api.Delete(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, RemovePermissionResponse> success = (statusCode, phrase, json) =>
            {
                var message = MessageResponse.GetMessageResponse(json);

                return new RemovePermissionResponse.Success(statusCode, phrase, json, message.Message);
            };

            Func<string, string, RemovePermissionResponse> tokenExpired = (rp, b) => { return new RemovePermissionResponse.TokenExpired(rp, b); };
            Func<string, string, double, RemovePermissionResponse> limitReached = (rp, b, r) => { return new RemovePermissionResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, RemovePermissionResponse> failed = (sc, rp, b) => { return new RemovePermissionResponse.Failed(sc, rp, b); };
            Func<string, string, RemovePermissionResponse> forbidden = (rp, b) => { return new RemovePermissionResponse.Forbidden(rp, b); };


            return response.GetResponse( body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);

        }

        private static Permission GetPermission(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new Permission();

            return JsonConvert.DeserializeObject<Permission>(body);
        }

        private static IEnumerable<Permission> GetPermissions(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new List<Permission>();

            return JsonConvert.DeserializeObject<IEnumerable<Permission>>(body);

        }

    }
}
