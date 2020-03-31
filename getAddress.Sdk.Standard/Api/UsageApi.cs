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

        public const string V2Path = "v2/usage/";
        public const string V3Path = "v3/usage/";

        internal UsageApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey,api)
        {

        }

        public async Task<GetUsageResponse> Get(int day,int month, int year)
        {
            return await Get(Api, V2Path, AdminKey,day,month,year);
        }
        public async Task<GetUsageResponse> Get(GetUsageRequest request)
        {
            return await Get(Api, V2Path, AdminKey, request);
        }

        public async Task<GetUsageV3Response> GetV3(GetUsageRequest request)
        {
            return await GetV3(Api, V3Path, AdminKey, request);
        }

        public async static Task<GetUsageResponse> Get(GetAddesssApi api, string path,
            AdminKey adminKey, GetUsageRequest request)
        {
            return await Get(api, path, adminKey, request.Day,request.Month,request.Year);
        }

        public async static Task<GetUsageV3Response> GetV3(GetAddesssApi api, string path,
            AdminKey adminKey, GetUsageRequest request)
        {
            return await GetV3(api, path, adminKey, request.Day, request.Month, request.Year);
        }

        public async static Task<GetUsageResponse> Get(GetAddesssApi api, string path, 
            AdminKey adminKey,int day, int month, int year)
        {
            var fullPath = $"{path}{day}/{month}/{year}";

            return await Get(api, fullPath, adminKey);
        }

        public async static Task<GetUsageV3Response> GetV3(GetAddesssApi api, string path,
            AdminKey adminKey, int day, int month, int year)
        {
            var fullPath = $"{path}{day}/{month}/{year}";

            return await GetV3(api, fullPath, adminKey);
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
            return await Get(Api, V2Path, AdminKey);
        }

        public async Task<GetUsageV3Response> GetV3()
        {
            return await GetV3(Api, V3Path, AdminKey);
        }

        public async static Task<GetUsageResponse> Get(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            
            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, GetUsageResponse> success = (statusCode, phrase, json) =>
            {
                var usage = GetUsage(json);

                return new GetUsageResponse.Success(statusCode, phrase, json, usage.Count,
                    usage.Limit1, usage.Limit2);
            };

            Func<string, string, GetUsageResponse> tokenExpired = (rp, b) => { return new GetUsageResponse.TokenExpired(rp, b); };
            Func<string, string, int, GetUsageResponse> limitReached = (rp, b, r) => { return new GetUsageResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, GetUsageResponse> failed = (sc, rp, b) => { return new GetUsageResponse.Failed(sc, rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed);

        }

        public async static Task<GetUsageV3Response> GetV3(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, GetUsageV3Response> success = (statusCode, phrase, json) =>
            {
                var usage = GetUsageV3(json);

                return new GetUsageV3Response.Success(statusCode, phrase, json, usage.DailyLimit,
                    usage.UsageToday, usage.MonthlyBuffer, usage.MonthlyBufferUsed);
            };

            Func<string, string, GetUsageV3Response> tokenExpired = (rp, b) => { return new GetUsageV3Response.TokenExpired(rp, b); };
            Func<string, string, int, GetUsageV3Response> limitReached = (rp, b, r) => { return new GetUsageV3Response.RateLimitedReached(rp, b, r); };
            Func<int, string, string, GetUsageV3Response> failed = (sc, rp, b) => { return new GetUsageV3Response.Failed(sc, rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed);
        }

        public async static Task<ListUsageResponse> List(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, ListUsageResponse> success = (statusCode, phrase, json) =>
            {
                var usages = ListUsages(json);

                return new ListUsageResponse.Success(statusCode, phrase, json, usages);
            };

            Func<string, string, ListUsageResponse> tokenExpired = (rp, b) => { return new ListUsageResponse.TokenExpired(rp, b); };
            Func<string, string, int, ListUsageResponse> limitReached = (rp, b, r) => { return new ListUsageResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, ListUsageResponse> failed = (sc, rp, b) => { return new ListUsageResponse.Failed(sc, rp, b); };

            return response.GetResponse( body,
                success,
                tokenExpired,
                limitReached,
                failed);

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

        private static UsageV3 GetUsageV3(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new UsageV3();

            var json = JsonConvert.DeserializeObject<dynamic>(body);

            return new UsageV3
            {
                UsageToday = json.usage_today,
                DailyLimit = json.daily_limit,
                MonthlyBuffer = json.monthly_buffer,
                MonthlyBufferUsed = json.monthly_buffer_used
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
