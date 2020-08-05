using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class BillingAddressApi: AdminApiBase
    {
        public const string Path = "billing-address/";

        internal BillingAddressApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey,api)
        {

        }

        public async Task<BillingAddressResponse> Get()
        {
            return await Get(Api, Path, AdminKey);
        }

        public async static Task<BillingAddressResponse> Get(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));


            api.SetAuthorizationKey(adminKey);

            var response = await api.HttpGet(path);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, BillingAddressResponse> success = (statusCode, phrase, json) =>
            {
                var address = GetBillingAddress(json);

                return new BillingAddressResponse.Success(statusCode, phrase, json,
                    address.Line1, address.Line2, address.Line3, address.TownOrCity, address.County, address.Postcode);
            };

            Func<string, string, BillingAddressResponse> tokenExpired = (rp, b) => { return new BillingAddressResponse.TokenExpired(rp, b); };
            Func<string, string, double, BillingAddressResponse> limitReached = (rp, b, r) => { return new BillingAddressResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, BillingAddressResponse> failed = (sc, rp, b) => { return new BillingAddressResponse.Failed(sc, rp, b); };
            Func<string, string, BillingAddressResponse> forbidden = (rp, b) => { return new BillingAddressResponse.Forbidden(rp, b); };


            return response.GetResponse( body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden
                );

        }

        public async Task<BillingAddressResponse> Update(BillingAddressRequest request)
        {
            return await Update(Api, request, Path, AdminKey);
        }

        public async static Task<BillingAddressResponse> Update(GetAddesssApi api, BillingAddressRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Put(path, request);

            var body = await response.Content.ReadAsStringAsync();


            Func<int, string, string, BillingAddressResponse> success = (statusCode, phrase, json) =>
            {
                var address = GetBillingAddress(json);

                return new BillingAddressResponse.Success(statusCode, phrase, json,
                   address.Line1, address.Line2, address.Line3, address.TownOrCity, address.County, address.Postcode);
            };

            Func<string, string, BillingAddressResponse> tokenExpired = (rp, b) => { return new BillingAddressResponse.TokenExpired(rp, b); };
            Func<string, string, double, BillingAddressResponse> limitReached = (rp, b, r) => { return new BillingAddressResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, BillingAddressResponse> failed = (sc, rp, b) => { return new BillingAddressResponse.Failed(sc, rp, b); };
            Func<string, string, BillingAddressResponse> forbidden = (rp, b) => { return new BillingAddressResponse.Forbidden(rp, b); };

            return response.GetResponse( body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden
                );

        }

        private static BillingAddress GetBillingAddress(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new BillingAddress();

            return JsonConvert.DeserializeObject<BillingAddress>(body);
        }

        private class BillingAddress
        {
            public string Line1 { get; set; }

            public string Line2 { get; set; }

            public string Line3 { get; set; }

            public string TownOrCity { get; set; }

            public string County { get; set; }

            public string Postcode { get; set; }
        }

    }
}
