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
    public class IpAddressWhitelistApi : AdminApiBase
    {

        public const string Path = "security/ip-address-whitelist/";

        internal IpAddressWhitelistApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey,api)
        {

        }

        public async Task<AddIpAddressWhitelistResponse> Add(AddIpAddressWhitelistRequest request)
        {
            return await Add(Api, request, Path,AdminKey);
        }

        public async static Task<AddIpAddressWhitelistResponse> Add(GetAddesssApi api, AddIpAddressWhitelistRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Post(path, request);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, AddIpAddressWhitelistResponse> success = (statusCode, phrase, json) =>
            {
                var messageAndId = MessageAndId.GetMessageAndId(json);

                return new AddIpAddressWhitelistResponse.Success(statusCode, phrase, json, messageAndId.Message, messageAndId.Id);
            };

            Func<string, string, AddIpAddressWhitelistResponse> tokenExpired = (rp, b) => { return new AddIpAddressWhitelistResponse.TokenExpired(rp, b); };
            Func<string, string, double, AddIpAddressWhitelistResponse> limitReached = (rp, b, r) => { return new AddIpAddressWhitelistResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, AddIpAddressWhitelistResponse> failed = (sc, rp, b) => { return new AddIpAddressWhitelistResponse.Failed(sc, rp, b); };
            Func<string, string, AddIpAddressWhitelistResponse> forbidden = (rp, b) => { return new AddIpAddressWhitelistResponse.Forbidden(rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);

            
        }

        public async  Task<RemoveIpAddressWhitelistResponse> Remove(RemoveIpAddressWhitelistRequest request)
        {
            return await Remove(Api, request, Path, AdminKey);
        }

        public async static Task<RemoveIpAddressWhitelistResponse> Remove(GetAddesssApi api, RemoveIpAddressWhitelistRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (path == null) throw new ArgumentNullException(nameof(path));


            var fullPath = path + request.Id;

            api.SetAuthorizationKey(adminKey);

            var response = await api.Delete(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, RemoveIpAddressWhitelistResponse> success = (statusCode, phrase, json) =>
            {
                var message = GetMessage(json);

                return new RemoveIpAddressWhitelistResponse.Success(statusCode,phrase, json, message);
            };

            Func<string, string, RemoveIpAddressWhitelistResponse> tokenExpired = (rp, b) => { return new RemoveIpAddressWhitelistResponse.TokenExpired(rp, b); };
            Func<string, string, double, RemoveIpAddressWhitelistResponse> limitReached = (rp, b, r) => { return new RemoveIpAddressWhitelistResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, RemoveIpAddressWhitelistResponse> failed = (sc, rp, b) => { return new RemoveIpAddressWhitelistResponse.Failed(sc, rp, b); };
            Func<string, string, RemoveIpAddressWhitelistResponse> forbidden = (rp, b) => { return new RemoveIpAddressWhitelistResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);

        }

        public async  Task<ListIpAddressWhitelistResponse> List()
        {
            return await List(Api, Path, AdminKey);
        }

        public async static Task<ListIpAddressWhitelistResponse> List(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));

            api.SetAuthorizationKey(adminKey);

            var response = await api.HttpGet(path);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, ListIpAddressWhitelistResponse> success = (statusCode, phrase, json) =>
            {
                var list = GetLists(json);

                return new ListIpAddressWhitelistResponse.Success(statusCode, phrase, json, list);
            };

            Func<string, string, ListIpAddressWhitelistResponse> tokenExpired = (rp, b) => { return new ListIpAddressWhitelistResponse.TokenExpired(rp, b); };
            Func<string, string, double, ListIpAddressWhitelistResponse> limitReached = (rp, b, r) => { return new ListIpAddressWhitelistResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, ListIpAddressWhitelistResponse> failed = (sc, rp, b) => { return new ListIpAddressWhitelistResponse.Failed(sc, rp, b); };
            Func<string, string, ListIpAddressWhitelistResponse> forbidden = (rp, b) => { return new ListIpAddressWhitelistResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);

        }


        private static IEnumerable<IpAddressWhitelist> GetLists(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new List<IpAddressWhitelist>();

            var json = JsonConvert.DeserializeObject<JArray>(body);

            var list = new List<IpAddressWhitelist>();

            foreach (dynamic jsonObj in json)
            {
                var obj = new IpAddressWhitelist
                {
                    Id = jsonObj.id,
                    Value = jsonObj.value
                };

                list.Add(obj);
            }

            return list;
        }

        public async Task<GetIpAddressWhitelistResponse> Get(GetIpAddressWhitelistRequest request)
        {
            return await Get(Api, Path, AdminKey, request);
        }

        public async Task<GetIpAddressWhitelistResponse> Get(string id)
        {
            return await Get(Api, Path, AdminKey, id);
        }

        public async static Task<GetIpAddressWhitelistResponse> Get(GetAddesssApi api, string path, AdminKey adminKey, GetIpAddressWhitelistRequest request)
        {
            return await Get(api, Path, adminKey, request.Id);
        }

        public async static Task<GetIpAddressWhitelistResponse> Get(GetAddesssApi api, string path, AdminKey adminKey, string id)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));
            if (id == null) throw new ArgumentNullException(nameof(id));

            var fullPath = path + id;

            api.SetAuthorizationKey(adminKey);

            var response = await api.HttpGet(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, GetIpAddressWhitelistResponse> success = (statusCode, phrase, json) =>
            {
                var valueAndId = GetIpAddressWhitelist(json);

                return new GetIpAddressWhitelistResponse.Success(statusCode, phrase, json, valueAndId.Id, valueAndId.Value);
            };

            Func<string, string, GetIpAddressWhitelistResponse> tokenExpired = (rp, b) => { return new GetIpAddressWhitelistResponse.TokenExpired(rp, b); };
            Func<string, string, double, GetIpAddressWhitelistResponse> limitReached = (rp, b, r) => { return new GetIpAddressWhitelistResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, GetIpAddressWhitelistResponse> failed = (sc, rp, b) => { return new GetIpAddressWhitelistResponse.Failed(sc, rp, b); };
            Func<string, string, GetIpAddressWhitelistResponse> forbidden = (rp, b) => { return new GetIpAddressWhitelistResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);

        }

        protected static IpAddressWhitelist GetIpAddressWhitelist(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new IpAddressWhitelist();

            var json = JsonConvert.DeserializeObject<dynamic>(body);

            return new IpAddressWhitelist
            {
                Id = json.id,
                Value = json.value
            };
        }
    }
}
