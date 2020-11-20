using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class PlansApi: AdminApiBase
    {
        public const string Path = "plans/";

        internal PlansApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey,api)
        {

        }
        public async Task<PlansResponse> Get()
        {
            return await Get(Api, Path, AdminKey);
        }
        public async static Task<PlansResponse> Get(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));

            api.SetAuthorizationKey(adminKey);

            var fullPath = path;

            var response = await api.HttpGet(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, PlansResponse> success = (statusCode, phrase, json) =>
            {
                var plans = GetPlanDetails(body);

                var successResponse =  new PlansResponse.Success(statusCode, phrase, json);

                successResponse.PlanDetails = plans;

                return successResponse;
            };

            Func<string, string, PlansResponse> tokenExpired = (rp, b) => { return new PlansResponse.TokenExpired(rp, b); };
            Func<string, string, double, PlansResponse> limitReached = (rp, b, r) => { return new PlansResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, PlansResponse> failed = (sc, rp, b) => { return new PlansResponse.Failed(sc, rp, b); };
            Func<string, string, PlansResponse> forbidden = (rp, b) => { return new PlansResponse.Forbidden(rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);

        }

        private static IEnumerable<PlanDetail> GetPlanDetails(string body)
        {
            var list = new List<PlanDetail>();

            if (string.IsNullOrWhiteSpace(body)) return list;

            var json = JsonConvert.DeserializeObject<dynamic>(body);

            foreach(var plan in json.plans)
            {
                var planDetail = new PlanDetail
                {
                    Description = plan.description,
                    Amount = plan.amount,
                    Name = plan.name,
                    Period = plan.period,
                    DailyLimit = plan.daily_limit
                };

                list.Add(planDetail);
            }

            return list;
        }
    }
}
