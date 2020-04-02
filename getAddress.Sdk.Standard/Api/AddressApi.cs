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

            var fullPath = GetPath(path, request);

            api.SetAuthorizationKey(apiKey);

            var response = await api.Get(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, GetAddressResponse> success = (statusCode, phrase, json) =>
            {
                var addressesBody = GetAddressBody(json);
                double latitude = addressesBody.Item1;
                double longitude = addressesBody.Item2;
                var addresses = addressesBody.Item3;

                return new GetAddressResponse.Success(statusCode, phrase, json, latitude, longitude, addresses);
            };

            Func<string, string,GetAddressResponse> tokenExpired = (rp, b) => { return new GetAddressResponse.TokenExpired(rp, b); };
            Func<string, string,GetAddressResponse> notFound =  (rp,b) => { return new GetAddressResponse.NotFound(rp, b); };
            Func<string, string, GetAddressResponse> invalidPostcode = (rp, b) => { return new GetAddressResponse.InvalidPostcode(rp, b); };
            Func<string, string, GetAddressResponse> accountExpired = (rp, b) => { return new GetAddressResponse.AccountExpired(rp, b); };
            Func<string, string, GetAddressResponse> forbidden = (rp, b) => { return new GetAddressResponse.Forbidden(rp, b); };
            Func<string, string, GetAddressResponse> limitReached = (rp, b) => { return new GetAddressResponse.LimitReached(rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                GetAddressResponse.RateLimitedReached.NewRateLimitedReached,
                GetAddressResponse.Failed.NewFailed,
                forbidden,
                notFound:notFound,
                invalidPostcode: invalidPostcode,
                accountExpired: accountExpired,
                limitReached:limitReached
                );


           
        }

        private static string GetPath(string path, GetAddressRequest request) 
        {
            if (!string.IsNullOrWhiteSpace(request.House))
            {
                return $"{path}{request.Postcode}/{request.House}/?sort={request.Sort}&fuzzy={request.Fuzzy}";
            }
            else
            {
                return $"{path}{request.Postcode}/?sort={request.Sort}&fuzzy={request.Fuzzy}";
            }
        }

        private static string GetExpandedPath(string path, GetAddressRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.House))
            {
                return $"{path}{request.Postcode}/{request.House}/?sort={request.Sort}&expand={true}&fuzzy={request.Fuzzy}";
            }
            else
            {
                return $"{path}{request.Postcode}/?sort={request.Sort}&expand={true}&fuzzy={request.Fuzzy}";
            }
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

            var fullPath = GetExpandedPath(path, request);

            api.SetAuthorizationKey(apiKey);

            var response = await api.Get(fullPath);

            var body = await response.Content.ReadAsStringAsync();


            Func<int, string, string, GetExpandedAddressResponse> success = (statusCode, phrase, json) =>
            {
                var addressesBody = GetExpandedAddressFromBody(json);
                double latitude = addressesBody.Item1;
                double longitude = addressesBody.Item2;
                var addresses = addressesBody.Item4;
                var postcode = addressesBody.Item3;
                return new GetExpandedAddressResponse.Success(statusCode, phrase, json, latitude, longitude, postcode, addresses);
            };

            Func<string, string, GetExpandedAddressResponse> tokenExpired = (rp, b) => { return new GetExpandedAddressResponse.TokenExpired(rp, b); };
            Func<string, string, GetExpandedAddressResponse> notFound = (rp, b) => { return new GetExpandedAddressResponse.NotFound(rp, b); };
            Func<string, string, GetExpandedAddressResponse> invalidPostcode = (rp, b) => { return new GetExpandedAddressResponse.InvalidPostcode(rp, b); };
            Func<string, string, GetExpandedAddressResponse> accountExpired = (rp, b) => { return new GetExpandedAddressResponse.AccountExpired(rp, b); };
            Func<string, string, GetExpandedAddressResponse> forbidden = (rp, b) => { return new GetExpandedAddressResponse.Forbidden(rp, b); };
            Func<string, string, GetExpandedAddressResponse> limitReached = (rp, b) => { return new GetExpandedAddressResponse.LimitReached(rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                GetExpandedAddressResponse.RateLimitedReached.NewRateLimitedReached,
                GetExpandedAddressResponse.Failed.NewFailed,
                forbidden,
                notFound: notFound,
                invalidPostcode: invalidPostcode,
                accountExpired: accountExpired,
                limitReached: limitReached
                );

        }

        public async Task<PlaceDetailsResponse> PlaceDetails(PlaceDetailsRequest request)
        {
            var path = "google/place-details/";

            return await PlaceDetails(Api, path, this.ApiKey, request);
        }

        public async static Task<PlaceDetailsResponse> PlaceDetails(GetAddesssApi api, string path, ApiKey apiKey, PlaceDetailsRequest request)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
            if (request == null) throw new ArgumentNullException(nameof(request));

            var fullPath = $"{path}{request.PlaceId.Value}/?google-api-key={request.GoogleApiKey.Value}";

            api.SetAuthorizationKey(apiKey);

            var response = await api.Get(fullPath);

            var body = await response.Content.ReadAsStringAsync();


            Func<int, string, string, PlaceDetailsResponse> success = (statusCode, phrase, json) =>
            {
                var addressBody = GetSingleExpandedAddressFromBody(json);

                double latitude = addressBody.Item1;
                double longitude = addressBody.Item2;
                var address = addressBody.Item4;
                var postcode = addressBody.Item3;

                return new PlaceDetailsResponse.Success(statusCode, phrase, json, latitude, longitude, postcode, address);
            };

            Func<string, string, PlaceDetailsResponse> tokenExpired = (rp, b) => { return new PlaceDetailsResponse.TokenExpired(rp, b); };
            Func<string, string, PlaceDetailsResponse> forbidden = (rp, b) => { return new PlaceDetailsResponse.Forbidden(rp, b); };
            Func<string, string, PlaceDetailsResponse> limitReached = (rp, b) => { return new PlaceDetailsResponse.LimitReached(rp, b); };


            return response.GetResponse( body,
                success,
                tokenExpired,
                PlaceDetailsResponse.RateLimitedReached.NewRateLimitedReached,
                PlaceDetailsResponse.Failed.NewFailed,
                forbidden,
                limitReached:limitReached
                );

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

        private static Tuple<double, double,string, IEnumerable<ExpandedAddress>> GetExpandedAddressFromBody(string body)
        {
            var addressList = new List<ExpandedAddress>();

            if (string.IsNullOrWhiteSpace(body)) return new Tuple<double, double,string, IEnumerable<ExpandedAddress>>(0, 0,string.Empty, addressList);

            var json = JsonConvert.DeserializeObject<dynamic>(body);
            double latitude = json.latitude;
            double longitude = json.longitude;
            string postcode = json.postcode;

            foreach (var address in json.addresses)
            {
                var expandedAddress = GetExpandedAddress(address);

                addressList.Add(expandedAddress);
            }

            return new Tuple<double, double, string,IEnumerable<ExpandedAddress>>(latitude, longitude,postcode, addressList);
        }

        private static Tuple<double, double, string, ExpandedAddress> GetSingleExpandedAddressFromBody(string body)
        {

            if (string.IsNullOrWhiteSpace(body)) return new Tuple<double, double, string, ExpandedAddress>(0, 0, string.Empty, null);

            var json = JsonConvert.DeserializeObject<dynamic>(body);
            double latitude = json.latitude;
            double longitude = json.longitude;
            string postcode = json.postcode;
            var expandedAddress = GetExpandedAddress(json.address);

            return new Tuple<double, double, string, ExpandedAddress>(latitude, longitude, postcode, expandedAddress);
        }


        private static ExpandedAddress GetExpandedAddress(dynamic address)
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

            return expandedAddress;
        }
    }
}
