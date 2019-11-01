using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var fullPath = $"{path}{request.Postcode}/{request.House}?sort={request.Sort}&fuzzy={request.Fuzzy}";

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


        public async Task<GetExpandedAddressResponse> GetExpanded(GetAddressRequest request)
        {
            return await GetExpanded(Api, Path, this.ApiKey, request);
        }
        public async static Task<GetExpandedAddressResponse> GetExpanded(GetAddesssApi api, string path, ApiKey apiKey, GetAddressRequest request)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
            if (request == null) throw new ArgumentNullException(nameof(request));

            var fullPath = $"{path}{request.Postcode}/{request.House}?sort={request.Sort}&expand={true}&fuzzy={request.Fuzzy}";

            api.SetAuthorizationKey(apiKey);

            var response = await api.Get(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var addressesBody = GetExpandedAddressBody(body);
                double latitude = addressesBody.Item1;
                double longitude = addressesBody.Item2;
                var addresses = addressesBody.Item4;
                var postcode = addressesBody.Item3;
                return new GetExpandedAddressResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, latitude, longitude,postcode, addresses);
            }

            return new GetExpandedAddressResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);//todo: move failed responses
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

        private static Tuple<double, double,string, IEnumerable<ExpandedAddress>> GetExpandedAddressBody(string body)
        {
            var addressList = new List<ExpandedAddress>();

            if (string.IsNullOrWhiteSpace(body)) return new Tuple<double, double,string, IEnumerable<ExpandedAddress>>(0, 0,string.Empty, addressList);

            var json = JsonConvert.DeserializeObject<dynamic>(body);
            double latitude = json.latitude;
            double longitude = json.longitude;
            string postcode = json.postcode;

            foreach (var address in json.addresses)
            {
                string thoroughfare = address.thoroughfare; 
                string buildingName = address.building_name;
                string subuildingName = address.sub_building_name;
                string subuildingNumber = address.sub_building_number;
                string buildingNumber = address.building_number;
                string line1 = address.line_1;
                string line2 = address.line_2;
                string line3 = address.line_3;
                string line4 = address.line_4;
                string locality = address.locality;
                string townOrCity = address.town_or_city;
                string county = address.county;
                string district = address.district;
                string country = address.country;

                JArray jformattedAddress = address.formatted_address;

                string[] formattedAddress = jformattedAddress.Select(jv => (string)jv).ToArray();

                var expandedAddress = new ExpandedAddress
                {
                    FormattedAddress = new FormattedAddress
                    {
                       Line1 = formattedAddress[0],
                       Line2 = formattedAddress[1],
                       Line3 = formattedAddress[2],
                       Line4 = formattedAddress[3],
                       County = formattedAddress[4]
                    },
                    Thoroughfare = thoroughfare,
                    BuildingName = buildingName,
                    SubuildingName = subuildingName,
                    SubuildingNumber = subuildingNumber,
                    BuildingNumber = buildingNumber,
                    Line1 = line1,
                    Line2 = line2,
                    Line3 = line3,
                    Line4 = line4,
                    County = county,
                    Locality = locality,
                    TownOrCity = townOrCity,
                    District = district,
                    Country = country
                };

                addressList.Add(expandedAddress);
            }

            return new Tuple<double, double, string,IEnumerable<ExpandedAddress>>(latitude, longitude,postcode, addressList);
        }
    }
}
