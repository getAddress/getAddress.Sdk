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

            Func<int, string, string, AddPrivateAddressResponse> success = (statusCode, phrase, json) => 
            {
                var messageAndId = MessageAndId.GetMessageAndId(json);
                return new AddPrivateAddressResponse.Success(statusCode,phrase, json, messageAndId.Message, messageAndId.Id);
            };

            Func<string, string, AddPrivateAddressResponse> forbidden = (rp, b) => { return new AddPrivateAddressResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                AddPrivateAddressResponse.TokenExpired.NewTokenExpired,
                AddPrivateAddressResponse.RateLimitedReached.NewRateLimitedReached,
                AddPrivateAddressResponse.Failed.NewFailed,
                forbidden
                );

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

            Func<string, string, RemovePrivateAddressResponse> forbidden = (rp, b) => { return new RemovePrivateAddressResponse.Forbidden(rp, b); };


            return response.GetResponse<RemovePrivateAddressResponse>(body,
                RemovePrivateAddressResponse.Success.NewSuccess,
                RemovePrivateAddressResponse.TokenExpired.NewTokenExpired,
                RemovePrivateAddressResponse.RateLimitedReached.NewRateLimitedReached,
                RemovePrivateAddressResponse.Failed.NewFailed,
                forbidden
                );

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

            var response = await api.HttpGet(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, ListPrivateAddressResponse> success = (statusCode, phrase, json) =>
            {
                var addresses = GetPrivateAddresses(json);

                return ListPrivateAddressResponse.Success.NewSuccess (statusCode, phrase, json, addresses);
            };


            Func<string, string, ListPrivateAddressResponse> forbidden = (rp, b) => { return new ListPrivateAddressResponse.Forbidden(rp, b); };


            return response.GetResponse<ListPrivateAddressResponse>(body,
                success,
                ListPrivateAddressResponse.TokenExpired.NewTokenExpired,
                ListPrivateAddressResponse.RateLimitedReached.NewRateLimitedReached,
                ListPrivateAddressResponse.Failed.NewFailed,
                forbidden
                );
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

            var response = await api.HttpGet(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, GetPrivateAddressResponse> success = (statusCode, phrase, json) =>
            {
                var address = GetPrivateAddress(json);

                return GetPrivateAddressResponse.Success.NewSuccess(statusCode, phrase, json, address);
            };

            Func<string, string, GetPrivateAddressResponse> forbidden = (rp, b) => { return new GetPrivateAddressResponse.Forbidden(rp, b); };


            return response.GetResponse<GetPrivateAddressResponse>(body,
                success,
                GetPrivateAddressResponse.TokenExpired.NewTokenExpired,
                GetPrivateAddressResponse.RateLimitedReached.NewRateLimitedReached,
                GetPrivateAddressResponse.Failed.NewFailed,
                forbidden
                );
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
