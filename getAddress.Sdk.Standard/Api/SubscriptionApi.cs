using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class SubscriptionApi: AdminApiBase
    {
        public const string Path = "subscription/";

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

            var response = await api.Put(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, UnsubscribeResponse> success = (statusCode, phrase, json) =>
            {
                return new UnsubscribeResponse.Success(statusCode, phrase, json);
            };

            Func<string, string, UnsubscribeResponse> tokenExpired = (rp, b) => { return new UnsubscribeResponse.TokenExpired(rp, b); };
            Func<string, string, double, UnsubscribeResponse> limitReached = (rp, b, r) => { return new UnsubscribeResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, UnsubscribeResponse> failed = (sc, rp, b) => { return new UnsubscribeResponse.Failed(sc, rp, b); };
            Func<string, string, UnsubscribeResponse> forbidden = (rp, b) => { return new UnsubscribeResponse.Forbidden(rp, b); };



            return response.GetResponse( body,
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
