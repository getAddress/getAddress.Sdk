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

            if (response.IsSuccessStatusCode)
            {
                return new UnsubscribeResponse.Success((int)response.StatusCode, response.ReasonPhrase, body);
            }
            else if (response.HasTokenExpired())
            {
                return new UnsubscribeResponse.TokenExpired(response.ReasonPhrase, body);
            }

            return new UnsubscribeResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
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

            var response = await api.Get(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var subscription = GetSubscription(body);

                return new SubscriptionResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, subscription);
            }
            else if (response.HasTokenExpired())
            {
                return new SubscriptionResponse.TokenExpired(response.ReasonPhrase, body);
            }

            return new SubscriptionResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
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
