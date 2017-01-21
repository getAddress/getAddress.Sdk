using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class UsageApi: AdminApiBase
    {

        public const string Path = "usage/";

        internal UsageApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey,api)
        {

        }
        public async Task<GetUsageResponse> Get(int day,int month, int year)
        {
            return await Get(Api, Path, AdminKey,day,month,year);
        }

        public async static Task<GetUsageResponse> Get(GetAddesssApi api, string path, 
            AdminKey adminKey,int day, int month, int year)
        {
            var fullPath = $"{path}{day}/{month}/{year}";

            return await Get(api, fullPath, adminKey);
        }
        public async Task<GetUsageResponse> Get()
        {
            return await Get(Api, Path, AdminKey);
        }

        public async static Task<GetUsageResponse> Get(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));
            

            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var usage = GetUsage(body);

                return new GetUsageResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, usage.Counter,usage.Limit1, usage.Limit2);
            }

            return new GetUsageResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }


        private static Usage GetUsage(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new Usage();

            var json = JsonConvert.DeserializeObject<dynamic>(body);

            return new Usage
            {
                Counter = json.DailyRequestCount,
                Limit1 = json.DailyRequestLimit1,
                Limit2 = json.DailyRequestLimit2
            };
        }

        private class Usage 
        {
            public int Counter { get; set; }
            public int Limit1 { get; set; }
            public int Limit2 { get; set; }
        }
    }
}
