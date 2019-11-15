using getAddress.Sdk.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getAddress.Sdk.Tests
{
    static class UrlHelper
    {
        public static Uri GetStagingUri()
        {
            var url = Environment.GetEnvironmentVariable("getaddress_staging_url", EnvironmentVariableTarget.User);

            if (string.IsNullOrWhiteSpace(url)) throw new Exception("Add your staging url to your Environmental Variables");

            return new Uri(url);
        }
    }
    static class KeyHelper
    {
        public static string GetAdminKey()
        {
            var adminKey = Environment.GetEnvironmentVariable("getaddress_adminkey", EnvironmentVariableTarget.User);

            if (string.IsNullOrWhiteSpace(adminKey)) throw new Exception("Add your admin key to your Environmental Variables");

            return adminKey;
        }

        public static string GetApiKey()
        {
            var apiKey = Environment.GetEnvironmentVariable("getaddress_apikey", EnvironmentVariableTarget.User);

            if (string.IsNullOrWhiteSpace(apiKey)) throw new Exception("Add your api key to your Environmental Variables");

            return apiKey;
        }

        public static string GetGoogleApiKey()
        {
            var apiKey = Environment.GetEnvironmentVariable("google_apikey", EnvironmentVariableTarget.User);

            if (string.IsNullOrWhiteSpace(apiKey)) throw new Exception("Add your google api key to your Environmental Variables");

            return apiKey;
        }

        public static GooglePlaceId GetGooglePlaceId()
        {
            var placeId = Environment.GetEnvironmentVariable("google_place_id", EnvironmentVariableTarget.User);

            if (string.IsNullOrWhiteSpace(placeId)) throw new Exception("Add your google place id key to your Environmental Variables");

            return new GooglePlaceId(placeId);
        }
    }
}
