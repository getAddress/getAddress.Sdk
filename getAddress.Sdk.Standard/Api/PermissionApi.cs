using getAddress.Api;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using System;
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

            var response = await api.Get(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var permission = GetPermission(body);

                return new PermissionResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, permission.Expires, permission.Permissions);
            }

            return new PermissionResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
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

            if (response.IsSuccessStatusCode)
            {
                var message = MessageResponse.GetMessageResponse(body);

                return new UpdatePermissionResponse.Success((int)response.StatusCode, response.ReasonPhrase,body, message.Message);
            }

            return new UpdatePermissionResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
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

            if (response.IsSuccessStatusCode)
            {
                var message = MessageResponse.GetMessageResponse(body);

                return new AddPermissionResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, message.Message);
            }

            return new AddPermissionResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
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

            if (response.IsSuccessStatusCode)
            {
                var message = MessageResponse.GetMessageResponse(body);

                return new RemovePermissionResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, message.Message);
            }

            return new RemovePermissionResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        private static Permission GetPermission(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new Permission();

            return JsonConvert.DeserializeObject<Permission>(body);
        }

        private class Permission
        {
            public DateTime Expires { get; set; }

            [JsonProperty("permissions")]
            public Permissions Permissions { get; set; }
        }

        

    }
}
