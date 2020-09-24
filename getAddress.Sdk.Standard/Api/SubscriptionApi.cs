using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class SubscriptionApi: AdminApiBase
    {
        public const string Path = "subscription/";
        public const string PathV2 = "v2/subscription/";

        internal SubscriptionApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey,api)
        {

        }

        public async Task<UnsubscribeResponse> Unsubscribe(string code = null)
        {
            return await Unsubscribe(Api, Path, AdminKey,code);
        }

        public async static Task<UnsubscribeResponse> Unsubscribe(GetAddesssApi api, string path, AdminKey adminKey, string code = null)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));

            api.SetAuthorizationKey(adminKey);

            var fullPath = path + "unsubscribe";

            if (!string.IsNullOrWhiteSpace(code))
            {
                fullPath += $"?code={code}";
            }

            if (api.HttpClient.DefaultRequestHeaders.Contains("api-version"))
            {
                api.HttpClient.DefaultRequestHeaders.Remove("api-version");
            }
            api.HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("api-version", "2020-09-09");

            var response = await api.Put(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, UnsubscribeResponse> success = (statusCode, phrase, json) =>
            {
                var responseId = GetResponseId(body);
                var successResult =  new UnsubscribeResponse.Success(statusCode, phrase, json);
                successResult.ResponseId = responseId;
                return successResult;
            };

            Func<string, string, UnsubscribeResponse> tokenExpired = (rp, b) => { return new UnsubscribeResponse.TokenExpired(rp, b); };
            Func<string, string, double, UnsubscribeResponse> limitReached = (rp, b, r) => { return new UnsubscribeResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, UnsubscribeResponse> failed = (sc, rp, b) => { return new UnsubscribeResponse.Failed(sc, rp, b); };
            Func<string, string, UnsubscribeResponse> forbidden = (rp, b) => { return new UnsubscribeResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);

        }


        public async Task<SubscriptionResponse> Get()
        {
            return await Get(Api, Path, AdminKey);
        }

        public async static Task<SubscriptionResponse> Get(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));

            api.SetAuthorizationKey(adminKey);

            var fullPath = path;

            var response = await api.HttpGet(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, SubscriptionResponse> success = (statusCode, phrase, json) =>
            {
                var subscription = GetSubscription(json);

                return new SubscriptionResponse.Success(statusCode, phrase, json, subscription);
            };

            Func<string, string, SubscriptionResponse> tokenExpired = (rp, b) => { return new SubscriptionResponse.TokenExpired(rp, b); };
            Func<string, string, double, SubscriptionResponse> limitReached = (rp, b, r) => { return new SubscriptionResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, SubscriptionResponse> failed = (sc, rp, b) => { return new SubscriptionResponse.Failed(sc, rp, b); };
            Func<string, string, SubscriptionResponse> forbidden = (rp, b) => { return new SubscriptionResponse.Forbidden(rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);

        }

        public async Task<SubscriptionV2Response> GetV2()
        {
            return await GetV2(Api, PathV2, AdminKey);
        }

        public async static Task<SubscriptionV2Response> GetV2(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));

            api.SetAuthorizationKey(adminKey);

            var fullPath = path;

            var response = await api.HttpGet(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, SubscriptionV2Response> success = (statusCode, phrase, json) =>
            {
                var subscription = GetSubscriptionV2(json);

                return new SubscriptionV2Response.Success(statusCode, phrase, json, subscription);
            };

            Func<string, string, SubscriptionV2Response> tokenExpired = (rp, b) => { return new SubscriptionV2Response.TokenExpired(rp, b); };
            Func<string, string, double, SubscriptionV2Response> limitReached = (rp, b, r) => { return new SubscriptionV2Response.RateLimitedReached(rp, b, r); };
            Func<int, string, string, SubscriptionV2Response> failed = (sc, rp, b) => { return new SubscriptionV2Response.Failed(sc, rp, b); };
            Func<string, string, SubscriptionV2Response> forbidden = (rp, b) => { return new SubscriptionV2Response.Forbidden(rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);

        }


        private static SubscriptionV2 GetSubscriptionV2(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new SubscriptionV2();

            var json = JsonConvert.DeserializeObject<dynamic>(body);

            return new SubscriptionV2
            {
                Plan = new Plan 
                { 
                    Amount = json.plan.amount,
                    Term = json.plan.term,
                    DailyLookupLimit1 = json.plan.daily_lookup_limit_1,
                    DailyLookupLimit2 = json.plan.daily_lookup_limit_2,
                },
                NextBillingDate = json.next_billing_date,
                PaymentMethod = json.payment_method,
                Status = json.status,
                Name = json.name
            };
        }

        private static string GetResponseId(string body)
        {

            if (string.IsNullOrWhiteSpace(body)) return string.Empty;

            var json = JsonConvert.DeserializeObject<dynamic>(body);

            string responseId = json.response_id;

            return responseId; ;
        }

        private static Subscription GetSubscription(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new Subscription();

            var json = JsonConvert.DeserializeObject<dynamic>(body);

            return new Subscription
            {
                Amount = json.amount,
                ExpiryDate = json.expiry_date,
                FirstDailyLimit = json.first_daily_limit,
                SecondDailyLimit = json.second_daily_limit,
                Term = json.term
            };
        }


    }
}
