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


            if (response.IsSuccessStatusCode)
            {
                var messageAndId = MessageAndId.GetMessageAndId(body);

                return new AddIpAddressWhitelistResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, messageAndId.Message, messageAndId.Id);
            }

            return new AddIpAddressWhitelistResponse.Failed((int)response.StatusCode, response.ReasonPhrase,body);
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

            if (response.IsSuccessStatusCode)
            {
                var message = GetMessage(body);

                return new RemoveIpAddressWhitelistResponse.Success((int)response.StatusCode, response.ReasonPhrase, body,message);
            }

            return new RemoveIpAddressWhitelistResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
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

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var list = GetLists(body);

                return new ListIpAddressWhitelistResponse.Success((int)response.StatusCode, response.ReasonPhrase, body,list);
            }

            return new ListIpAddressWhitelistResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
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


        public async Task<GetIpAddressWhitelistResponse> Get(string id)
        {
            return await Get(Api, Path, AdminKey, id);
        }

        public async static Task<GetIpAddressWhitelistResponse> Get(GetAddesssApi api, string path, AdminKey adminKey, string id)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));
            if (id == null) throw new ArgumentNullException(nameof(id));

            var fullPath = path + id;

            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var valueAndId = GetIpAddressWhitelist(body);

                return new GetIpAddressWhitelistResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, valueAndId.Id, valueAndId.Value);
            }

            return new GetIpAddressWhitelistResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
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
