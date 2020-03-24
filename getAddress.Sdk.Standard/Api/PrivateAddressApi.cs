using getAddress.Api;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class PrivateAddressApi: AdminApiBase
    {

        public const string Path = "private-address/";

        internal PrivateAddressApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey,api)
        {

        }

        public async Task<AddPrivateAddressResponse> Add(AddPrivateAddressRequest request)
        {
            return await Add(Api, request, Path, AdminKey);
        }

        public async static Task<AddPrivateAddressResponse> Add(GetAddesssApi api, AddPrivateAddressRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));

            var fullPath = path + request.Postcode;

            api.SetAuthorizationKey(adminKey);

            var response = await api.Post(fullPath, request);

            var body = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                var messageAndId = MessageAndId.GetMessageAndId(body);

                return new AddPrivateAddressResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, messageAndId.Message, messageAndId.Id);
            }
            else if (response.HasTokenExpired())
            {
                return new AddPrivateAddressResponse.TokenExpired(response.ReasonPhrase, body);
            }

            return new AddPrivateAddressResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        public async Task<RemovePrivateAddressResponse> Remove(RemovePrivateAddressRequest request)
        {
            return await Remove(Api, request, Path, AdminKey);
        }


        public async static Task<RemovePrivateAddressResponse> Remove(GetAddesssApi api, RemovePrivateAddressRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (path == null) throw new ArgumentNullException(nameof(path));


            var fullPath = $"{path}{request.Postcode}/{request.Id}";

            api.SetAuthorizationKey(adminKey);

            var response = await api.Delete(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return new RemovePrivateAddressResponse.Success((int)response.StatusCode, response.ReasonPhrase, body);
            }
            else if (response.HasTokenExpired())
            {
                return new RemovePrivateAddressResponse.TokenExpired(response.ReasonPhrase, body);
            }

            return new RemovePrivateAddressResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        public async Task<ListPrivateAddressResponse> List(ListPrivateAddressRequest request)
        {
            return await List(Api,request, Path, AdminKey);
        }

        public async static Task<ListPrivateAddressResponse> List(GetAddesssApi api, ListPrivateAddressRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (request == null) throw new ArgumentNullException(nameof(request)); 


            var fullPath = path + request.Postcode;

            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var addresses = GetPrivateAddresses(body);

                return new ListPrivateAddressResponse.Success((int)response.StatusCode, response.ReasonPhrase, body,addresses);
            }
            else if (response.HasTokenExpired())
            {
                return new ListPrivateAddressResponse.TokenExpired(response.ReasonPhrase, body);
            }

            return new ListPrivateAddressResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        public async Task<GetPrivateAddressResponse> Get(GetPrivateAddressRequest request)
        {
            return await Get(Api, Path, AdminKey, request);
        }

        public async static Task<GetPrivateAddressResponse> Get(GetAddesssApi api, string path, AdminKey adminKey, GetPrivateAddressRequest request)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));
            if (request == null) throw new ArgumentNullException(nameof(request));

            var fullPath = $"{path}{request.Postcode}/{request.Id}" ;

            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var addressAndId = GetPrivateAddress(body);
                return new GetPrivateAddressResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, addressAndId.Id,
                    addressAndId.Line1, addressAndId.Line2, addressAndId.Line3, addressAndId.Line4, addressAndId.Locality, addressAndId.TownOrCity, addressAndId.County);
            }
            else if (response.HasTokenExpired())
            {
                return new GetPrivateAddressResponse.TokenExpired(response.ReasonPhrase, body);
            }

            return new GetPrivateAddressResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }



        private static PrivateAddress GetPrivateAddress(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new PrivateAddress();

            var json = JsonConvert.DeserializeObject<dynamic>(body);

            return new PrivateAddress
            {
                Id = json.id,
                Line1 = json.line1,
                Line2 = json.line2,
                Line3 = json.line3,
                Line4 = json.line4,
                Locality = json.locality,
                TownOrCity = json.townOrcity,
                County = json.county

            };
        }

        private static IEnumerable<PrivateAddress> GetPrivateAddresses(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new List<PrivateAddress>();

            var jsons = JsonConvert.DeserializeObject<dynamic[]>(body);

            var addressList = new List<PrivateAddress>();
            foreach (var json in jsons)
            {
                var addressAndId = new PrivateAddress
                {
                    Id = json.id,
                    Line1 = json.line1,
                    Line2 = json.line2,
                    Line3 = json.line3,
                    Line4 = json.line4,
                    Locality = json.locality,
                    TownOrCity = json.townOrcity,
                    County = json.county

                };
                addressList.Add(addressAndId);
            }

            return addressList.ToArray();
        }

    }
}
