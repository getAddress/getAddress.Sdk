using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class AddressApi: ApiKeyBase
    {
        public const string Path = "find/";

        internal AddressApi(ApiKey apiKey, GetAddesssApi api) : base(apiKey,api)
        {

        }

        public async Task<GetAddressResponse> Get(GetAddressRequest request)
        {
            return await Get(Api, Path, this.ApiKey , request);
        }

        public async static Task<GetAddressResponse> Get(GetAddesssApi api, string path, ApiKey apiKey, GetAddressRequest request)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
            if (request == null) throw new ArgumentNullException(nameof(request));

            var fullPath = $"{path}{request.Postcode}/{request.House}?sort={request.Sort}";

            api.SetAuthorizationKey(apiKey);

            var response = await api.Get(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var addressesBody = GetAddressBody(body);
                double latitude = addressesBody.Item1;
                double longitude = addressesBody.Item2;
                var addresses = addressesBody.Item3;
                return new GetAddressResponse.Success((int)response.StatusCode, response.ReasonPhrase, body,latitude,longitude,addresses);
            }

            return new GetAddressResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);//todo: move failed responses
        }
        private static Tuple<double,double,IEnumerable<Address>> GetAddressBody(string body)
        {
            var addressList = new List<Address>();

            if (string.IsNullOrWhiteSpace(body)) return new Tuple<double, double, IEnumerable<Address>>(0, 0, addressList);

            var json = JsonConvert.DeserializeObject<dynamic>(body);
            double latitude = json.latitude;
            double longitude = json.longitude;

            foreach (var address in json.addresses)
            {
                var addressArr = ((string)address).Split(',');

                var addressObj = new Address
                {
                    Line1 = addressArr[0],
                    Line2 = addressArr[1],
                    Line3 = addressArr[2],
                    Line4 = addressArr[3],
                    Locality = addressArr[4],
                    TownOrCity = addressArr[5],
                    County = addressArr[6] 

                };

                addressList.Add(addressObj);
            }

            return new Tuple <double,double, IEnumerable<Address>>(latitude, longitude, addressList);
        }


    }
}
