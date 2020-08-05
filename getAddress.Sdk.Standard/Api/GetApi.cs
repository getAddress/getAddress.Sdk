using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class GetApi: ApiKeyBase
    {
        public const string Path = "get/";

        internal GetApi(ApiKey apiKey, GetAddesssApi api) : base(apiKey, api)
        {

        }

        public async Task<GetResponse> Address(string id, CancellationToken cancellationToken = default)
        {
            return await Address(this.Api, Path, this.ApiKey, id, cancellationToken: cancellationToken);
        }

        public async  Task<GetResponse> Address(Suggestion suggestion, CancellationToken cancellationToken = default)
        {
            if (suggestion is null)
            {
                throw new ArgumentNullException(nameof(suggestion));
            }

            return await Address(this.Api, Path, this.ApiKey, suggestion.Id, cancellationToken: cancellationToken);
        }

        public async static Task<GetResponse> Address(GetAddesssApi api, string path, ApiKey apiKey, 
            string id, CancellationToken cancellationToken = default)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("id is empty", nameof(id));
            }

            var fullPath = Path + id;

            api.SetAuthorizationKey(apiKey);

            var response = await api.HttpGet(fullPath, cancellationToken: cancellationToken);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, GetResponse> success = (statusCode, phrase, json) =>
            {
                var address = GetAddress(body);

                return new GetResponse.Success(statusCode, phrase, json, address);
            };

            Func<string, string, GetResponse> tokenExpired = (rp, b) => { return new GetResponse.TokenExpired(rp, b); };
            Func<string, string, GetResponse> forbidden = (rp, b) => { return new GetResponse.Forbidden(rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                GetResponse.RateLimitedReached.NewRateLimitedReached,
                GetResponse.Failed.NewFailed,
                forbidden
                );

        }

        private static GetAddress GetAddress(string body)
        {
            var address = JsonConvert.DeserializeObject<dynamic>(body);

            double latitude = address.latitude;
            double longitude = address.longitude;
            string postcode = address.postcode;
            bool residential = address.residential;
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

            var getAddress = new GetAddress
            {
                Latitude = latitude,
                Longitude = longitude,
                Postcode = postcode,
                Residential = residential,
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

            return getAddress;
        }
    }
}
