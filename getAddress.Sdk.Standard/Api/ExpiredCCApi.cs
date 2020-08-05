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

            Func<int, string, string, AddExpiredCCResponse> success = (statusCode, phrase, json) =>
            {
                var messageAndId = MessageAndId.GetMessageAndId(json);

                var id = long.Parse(messageAndId.Id);

                return new AddExpiredCCResponse.Success(statusCode, phrase, json, messageAndId.Message, id);
            };

            Func<string, string, AddExpiredCCResponse> tokenExpired = (rp, b) => { return new AddExpiredCCResponse.TokenExpired(rp, b); };
            Func<string, string, double, AddExpiredCCResponse> limitReached = (rp, b, r) => { return new AddExpiredCCResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, AddExpiredCCResponse> failed = (sc, rp, b) => { return new AddExpiredCCResponse.Failed(sc, rp, b); };
            Func<string, string, AddExpiredCCResponse> forbidden = (rp, b) => { return new AddExpiredCCResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);
           
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

            Func<int, string, string, RemoveExpiredCCResponse> success = (statusCode, phrase, json) =>
            {
                var m = GetMessage(json);

                return new RemoveExpiredCCResponse.Success(statusCode, phrase, json, m);
            };

            Func<string, string, RemoveExpiredCCResponse> tokenExpired = (rp, b) => { return new RemoveExpiredCCResponse.TokenExpired(rp, b); };
            Func<string, string, double, RemoveExpiredCCResponse> limitReached = (rp, b, r) => { return new RemoveExpiredCCResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, RemoveExpiredCCResponse> failed = (sc, rp, b) => { return new RemoveExpiredCCResponse.Failed(sc, rp, b); };
            Func<string, string, RemoveExpiredCCResponse> forbidden = (rp, b) => { return new RemoveExpiredCCResponse.Forbidden(rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden
                );
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

            var response = await api.HttpGet(path);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, ListExpiredCCResponse> success = (statusCode, phrase, json) =>
            {
                var list = ExpiredCC.DeserializeToList(json);

                return new ListExpiredCCResponse.Success(statusCode, phrase, json, list);
            };

            Func<string, string, ListExpiredCCResponse> tokenExpired = (rp, b) => { return new ListExpiredCCResponse.TokenExpired(rp, b); };
            Func<string, string, double, ListExpiredCCResponse> limitReached = (rp, b, r) => { return new ListExpiredCCResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, ListExpiredCCResponse> failed = (sc, rp, b) => { return new ListExpiredCCResponse.Failed(sc, rp, b); };
            Func<string, string, ListExpiredCCResponse> forbidden = (rp, b) => { return new ListExpiredCCResponse.Forbidden(rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);
        }

        private async static Task<GetExpiredCCResponse> GetCCInternal(GetAddesssApi api, string path, AdminKey adminKey, long id)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));

            api.SetAuthorizationKey(adminKey);

            var response = await api.HttpGet(path);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, GetExpiredCCResponse> success = (statusCode, phrase, json) =>
            {
                var cC = ExpiredCC.Deserialize(body);

                return new GetExpiredCCResponse.Success(statusCode, phrase, json, cC);
            };

            Func<string, string, GetExpiredCCResponse> tokenExpired = (rp, b) => { return new GetExpiredCCResponse.TokenExpired(rp, b); };
            Func<string, string, double, GetExpiredCCResponse> limitReached = (rp, b, r) => { return new GetExpiredCCResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, GetExpiredCCResponse> failed = (sc, rp, b) => { return new GetExpiredCCResponse.Failed(sc, rp, b); };
            Func<string, string, GetExpiredCCResponse> forbidden = (rp, b) => { return new GetExpiredCCResponse.Forbidden(rp, b); };


            return response.GetResponse( body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);

        }

    }
}
