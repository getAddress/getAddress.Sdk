using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class PaymentCardApi : AdminApiBase
    {
        public const string Path = "payment-card/";

        internal PaymentCardApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey, api)
        {

        }

        public async Task<PaymentCardResponse> List()
        {
            return await List(Api, Path, AdminKey);
        }

        public async static Task<PaymentCardResponse> List(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));

            api.SetAuthorizationKey(adminKey);

            var fullPath = path;

            var response = await api.HttpGet(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, PaymentCardResponse> success = (statusCode, phrase, json) =>
            {
                var paymentCards = GetPaymentCardList(json);

                return new PaymentCardResponse.Success(statusCode, phrase, json, paymentCards);
            };

            Func<string, string, PaymentCardResponse> tokenExpired = (rp, b) => { return new PaymentCardResponse.TokenExpired(rp, b); };
            Func<string, string, double, PaymentCardResponse> limitReached = (rp, b, r) => { return new PaymentCardResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, PaymentCardResponse> failed = (sc, rp, b) => { return new PaymentCardResponse.Failed(sc, rp, b); };
            Func<string, string, PaymentCardResponse> forbidden = (rp, b) => { return new PaymentCardResponse.Forbidden(rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);

        }

        private static PaymentCardList GetPaymentCardList(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new PaymentCardList();

            return JsonConvert.DeserializeObject<PaymentCardList>(body);

        }

    }
}
