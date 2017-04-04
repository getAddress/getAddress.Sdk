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

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var address = GetBillingAddress(body);

                return new BillingAddressResponse.Success((int)response.StatusCode, response.ReasonPhrase, body,
                    address.Line1, address.Line2, address.Line3, address.TownOrCity, address.County, address.Postcode);
            }

            return new BillingAddressResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        public async static Task<BillingAddressResponse> Update(GetAddesssApi api, BillingAddressRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Put(path, request);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var address = GetBillingAddress(body);

                return new BillingAddressResponse.Success((int)response.StatusCode, response.ReasonPhrase, body,
                   address.Line1, address.Line2, address.Line3, address.TownOrCity, address.County, address.Postcode);
            }

            return new BillingAddressResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
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
