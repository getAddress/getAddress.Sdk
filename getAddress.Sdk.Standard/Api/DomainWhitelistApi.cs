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
    public class DomainWhitelistApi : AdminApiBase
    {

        public const string Path = "security/domain-whitelist/";

        internal DomainWhitelistApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey,api)
        {

        }

        public async Task<AddDomainWhitelistResponse> Add(AddDomainWhitelistRequest request)
        {
            return await Add(Api, request, Path,AdminKey);
        }

        public async static Task<AddDomainWhitelistResponse> Add(GetAddesssApi api, AddDomainWhitelistRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Post(path, request);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, AddDomainWhitelistResponse> success = (statusCode, phrase, json) =>
            {
                var messageAndId = MessageAndId.GetMessageAndId(json);

                return new AddDomainWhitelistResponse.Success(statusCode, phrase, json, messageAndId.Message, messageAndId.Id);
            };

            Func<string, string, AddDomainWhitelistResponse> tokenExpired = (rp, b) => { return new AddDomainWhitelistResponse.TokenExpired(rp, b); };
            Func<string, string, double, AddDomainWhitelistResponse> limitReached = (rp, b, r) => { return new AddDomainWhitelistResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, AddDomainWhitelistResponse> failed = (sc, rp, b) => {
                return new AddDomainWhitelistResponse.Failed(sc, rp, b); 
            };
            Func<string, string, AddDomainWhitelistResponse> forbidden = (rp, b) => { return new AddDomainWhitelistResponse.Forbidden(rp, b); };


            return response.GetResponse( body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden
                );
        }

        public async  Task<RemoveDomainWhitelistResponse> Remove(RemoveDomainWhitelistRequest request)
        {
            return await Remove(Api, request, Path, AdminKey);
        }

        public async static Task<RemoveDomainWhitelistResponse> Remove(GetAddesssApi api, RemoveDomainWhitelistRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (path == null) throw new ArgumentNullException(nameof(path));

            var fullPath = path + request.Id;

            api.SetAuthorizationKey(adminKey);

            var response = await api.Delete(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, RemoveDomainWhitelistResponse> success = (statusCode, phrase, json) =>
            {
                var m = GetMessage(json);

                return new RemoveDomainWhitelistResponse.Success(statusCode, phrase, json, m);
            };

            Func<string, string, RemoveDomainWhitelistResponse> tokenExpired = (rp, b) => { return new RemoveDomainWhitelistResponse.TokenExpired(rp, b); };
            Func<string, string, double, RemoveDomainWhitelistResponse> limitReached = (rp, b, r) => { return new RemoveDomainWhitelistResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, RemoveDomainWhitelistResponse> failed = (sc, rp, b) => { return new RemoveDomainWhitelistResponse.Failed(sc, rp, b); };
            Func<string, string, RemoveDomainWhitelistResponse> forbidden = (rp, b) => { return new RemoveDomainWhitelistResponse.Forbidden(rp, b); };

            return response.GetResponse( body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden
                );

        }

        public async  Task<ListDomainWhitelistResponse> List()
        {
            return await List(Api, Path, AdminKey);
        }

        public async static Task<ListDomainWhitelistResponse> List(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));

            api.SetAuthorizationKey(adminKey);

            var response = await api.HttpGet(path);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, ListDomainWhitelistResponse> success = (statusCode, phrase, json) =>
            {
                var list = GetDomainWhitelists(json);

                return new ListDomainWhitelistResponse.Success(statusCode,phrase, json, list);
            };

            Func<string, string, ListDomainWhitelistResponse> tokenExpired = (rp, b) => { return new ListDomainWhitelistResponse.TokenExpired(rp, b); };
            Func<string, string, double, ListDomainWhitelistResponse> limitReached = (rp, b, r) => { return new ListDomainWhitelistResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, ListDomainWhitelistResponse> failed = (sc, rp, b) => { return new ListDomainWhitelistResponse.Failed(sc, rp, b); };
            Func<string, string, ListDomainWhitelistResponse> forbidden = (rp, b) => { return new ListDomainWhitelistResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden
                );

        }


        private static IEnumerable<DomainWhitelist> GetDomainWhitelists(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new List<DomainWhitelist>();

            var json = JsonConvert.DeserializeObject<JArray>(body);

            var list = new List<DomainWhitelist>();

            foreach (dynamic jsonDomain in json)
            {
                var domain =  new DomainWhitelist
                {
                    Id = jsonDomain.id,
                    Name = jsonDomain.name
                };

                list.Add(domain);
            }

            return list;
        }


        public async Task<GetDomainWhitelistResponse> Get(GetDomainWhitelistRequest request)
        {
            return await Get(Api, Path, AdminKey, request);
        }

        public async static Task<GetDomainWhitelistResponse> Get(GetAddesssApi api, string path, AdminKey adminKey, GetDomainWhitelistRequest request)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));
            if (request == null) throw new ArgumentNullException(nameof(request));

            var fullPath = path + request.Id;

            api.SetAuthorizationKey(adminKey);

            var response = await api.HttpGet(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, GetDomainWhitelistResponse> success = (statusCode, phrase, json) =>
            {
                var nameAndId = GetDomainWhitelist(json);

                return new GetDomainWhitelistResponse.Success(statusCode, phrase, json, nameAndId.Id, nameAndId.Name);
            };

            Func<string, string, GetDomainWhitelistResponse> tokenExpired = (rp, b) => { return new GetDomainWhitelistResponse.TokenExpired(rp, b); };
            Func<string, string, double, GetDomainWhitelistResponse> limitReached = (rp, b, r) => { return new GetDomainWhitelistResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, GetDomainWhitelistResponse> failed = (sc, rp, b) => { return new GetDomainWhitelistResponse.Failed(sc, rp, b); };
            Func<string, string, GetDomainWhitelistResponse> forbidden = (rp, b) => { return new GetDomainWhitelistResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden
                );

        }

        protected static DomainWhitelist GetDomainWhitelist(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new DomainWhitelist();

            var json = JsonConvert.DeserializeObject<dynamic>(body);

            return new DomainWhitelist
            {
                Id = json.id,
                Name = json.name
            };
        }
    }
}
