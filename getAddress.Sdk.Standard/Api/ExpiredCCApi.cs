using getAddress.Api;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class ExpiredCCApi : AdminApiBase
    {
        public const string Path = "cc/expired/";

        internal ExpiredCCApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey, api)
        {

        }

        public async Task<GetExpiredCCResponse> Get(GetExpiredCCRequest request)
        {
            return await Get(Api, Path, AdminKey, request);
        }

        public async static Task<GetExpiredCCResponse> Get(GetAddesssApi api, string path,
           AdminKey adminKey, GetExpiredCCRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var fullPath = $"{path}{request.Id}";

            return await GetCCInternal(api, fullPath, adminKey, request.Id);
        }

        public async Task<AddExpiredCCResponse> Add(AddExpiredCCRequest request)
        {
            return await Add(Api, request, Path, AdminKey);
        }

        public async static Task<AddExpiredCCResponse> Add(GetAddesssApi api, AddExpiredCCRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Post(path, request);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var messageAndId = MessageAndId.GetMessageAndId(body);

                var id = long.Parse(messageAndId.Id);

                return new AddExpiredCCResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, messageAndId.Message, id);
            }
            else if (response.HasTokenExpired())
            {
                return new AddExpiredCCResponse.TokenExpired(response.ReasonPhrase, body);
            }

            return new AddExpiredCCResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        public async Task<RemoveExpiredCCResponse> Remove(RemoveExpiredCCRequest request)
        {
            return await Remove(Api, request, Path, AdminKey);
        }

        public async static Task<RemoveExpiredCCResponse> Remove(GetAddesssApi api, RemoveExpiredCCRequest request, string path, AdminKey adminKey)
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

                return new RemoveExpiredCCResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, message);
            }
            else if (response.HasTokenExpired())
            {
                return new RemoveExpiredCCResponse.TokenExpired(response.ReasonPhrase, body);
            }

            return new RemoveExpiredCCResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        public async Task<ListExpiredCCResponse> List()
        {
            return await List(Api, Path, AdminKey);
        }

        public async static Task<ListExpiredCCResponse> List(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var list = ExpiredCC.DeserializeToList(body);

                return new ListExpiredCCResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, list);
            }
            else if (response.HasTokenExpired())
            {
                return new ListExpiredCCResponse.TokenExpired(response.ReasonPhrase, body);
            }

            return new ListExpiredCCResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        private async static Task<GetExpiredCCResponse> GetCCInternal(GetAddesssApi api, string path, AdminKey adminKey, long id)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var cC = ExpiredCC.Deserialize(body);

                return new GetExpiredCCResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, cC);
            }
            else if (response.HasTokenExpired())
            {
                return new GetExpiredCCResponse.TokenExpired(response.ReasonPhrase, body);
            }

            return new GetExpiredCCResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

    }
}
