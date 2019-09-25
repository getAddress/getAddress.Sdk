using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class UsageApi: AdminApiBase
    {

        public const string Path = "v2/usage/";

        internal UsageApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey,api)
        {

        }
        public async Task<GetUsageResponse> Get(int day,int month, int year)
        {
            return await Get(Api, Path, AdminKey,day,month,year);
        }
        public async Task<GetUsageResponse> Get(GetUsageRequest request)
        {
            return await Get(Api, Path, AdminKey, request);
        }

        public async static Task<GetUsageResponse> Get(GetAddesssApi api, string path,
            AdminKey adminKey, GetUsageRequest request)
        {
            return await Get(api, path, adminKey, request.Day,request.Month,request.Year);
        }

        public async static Task<GetUsageResponse> Get(GetAddesssApi api, string path, 
            AdminKey adminKey,int day, int month, int year)
        {
            var fullPath = $"{path}{day}/{month}/{year}";

            return await Get(api, fullPath, adminKey);
        }

        public async Task<ListUsageResponse> List(ListUsageRequest request)
        {
            return await List(Api, "usage", AdminKey, request);
        }

        public async static Task<ListUsageResponse> List(GetAddesssApi api, string path,
            AdminKey adminKey, ListUsageRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var fullPath = $"{path}/from/{request.From.Day}/{request.From.Month}/{request.From.Year}/To/{request.To.Day}/{request.To.Month}/{request.To.Year}";

            return await List(api, fullPath, adminKey);
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

                return new GetUsageResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, usage.Count,
                    usage.Limit1, usage.Limit2);
            }

            return new GetUsageResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        public async static Task<ListUsageResponse> List(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));


            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var usages = ListUsages(body);

                return new ListUsageResponse.Success((int)response.StatusCode, response.ReasonPhrase, body,usages);
            }

            return new ListUsageResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }


        private static Usage GetUsage(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new Usage();

            var json = JsonConvert.DeserializeObject<dynamic>(body);

            return new Usage
            {
                 Count = json.count,
                 Limit1 = json.limit1,
                 Limit2 = json.limit2
            };
        }

        private static IEnumerable<ListUsage> ListUsages(string body)
        {
            var list = new List<ListUsage>();

            if (string.IsNullOrWhiteSpace(body)) return list;

            var jsonArr = JArray.Parse(body);

            foreach (var jsonToken in jsonArr)
            {
                var usage = new ListUsage
                {
                    Count = jsonToken.Value<int>("count"),
                    Date = jsonToken.Value<DateTime>("date")
                };

                list.Add(usage);
            }

            return list;
        }
    }
}
