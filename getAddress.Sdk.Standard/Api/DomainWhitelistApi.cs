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


            if (response.IsSuccessStatusCode)
            {
                var messageAndId = GetMessageAndId(body);

                return new AddDomainWhitelistResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, messageAndId.Message, messageAndId.Id);
            }

            return new AddDomainWhitelistResponse.Failed((int)response.StatusCode, response.ReasonPhrase,body);
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

            if (response.IsSuccessStatusCode)
            {
                var message = GetMessage(body);

                return new RemoveDomainWhitelistResponse.Success((int)response.StatusCode, response.ReasonPhrase, body,message);
            }

            return new RemoveDomainWhitelistResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
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

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var list = GetDomainWhitelists(body);

                return new ListDomainWhitelistResponse.Success((int)response.StatusCode, response.ReasonPhrase, body,list);
            }

            return new ListDomainWhitelistResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
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

            var response = await api.Get(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var nameAndId = GetDomainWhitelist(body);

                return new GetDomainWhitelistResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, nameAndId.Id, nameAndId.Name);
            }

            return new GetDomainWhitelistResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
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
