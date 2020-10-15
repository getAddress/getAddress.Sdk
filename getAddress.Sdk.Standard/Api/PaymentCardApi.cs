using getAddress.Sdk.Api.Requests;
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

        public async Task<AddPaymentCardResponse> Add(AddPaymentCardRequest request)
        {
            return await Add(Api,request, Path, AdminKey);
        }

        public async static Task<AddPaymentCardResponse> Add(GetAddesssApi api, AddPaymentCardRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Post(path, request);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, AddPaymentCardResponse> success = (statusCode, phrase, json) =>
            {
                return new AddPaymentCardResponse.Success(statusCode, phrase, json,"");
            };

            Func<string, string, AddPaymentCardResponse> tokenExpired = (rp, b) => { return new AddPaymentCardResponse.TokenExpired(rp, b); };
            Func<string, string, double, AddPaymentCardResponse> limitReached = (rp, b, r) => { return new AddPaymentCardResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, AddPaymentCardResponse> failed = (sc, rp, b) => { return new AddPaymentCardResponse.Failed(sc, rp, b); };
            Func<string, string, AddPaymentCardResponse> forbidden = (rp, b) => { return new AddPaymentCardResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);
        }

        public async Task<RemovePaymentCardResponse> Remove(RemovePaymentCardRequest request)
        {
            return await Remove(Api, request, Path, AdminKey);
        }

        public async static Task<RemovePaymentCardResponse> Remove(GetAddesssApi api, RemovePaymentCardRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (path == null) throw new ArgumentNullException(nameof(path));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Delete(path);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, RemovePaymentCardResponse> success = (statusCode, phrase, json) =>
            {
                return new RemovePaymentCardResponse.Success(statusCode, phrase, json, string.Empty);
            };

            Func<string, string, RemovePaymentCardResponse> tokenExpired = (rp, b) => { return new RemovePaymentCardResponse.TokenExpired(rp, b); };
            Func<string, string, double, RemovePaymentCardResponse> limitReached = (rp, b, r) => { return new RemovePaymentCardResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, RemovePaymentCardResponse> failed = (sc, rp, b) => { return new RemovePaymentCardResponse.Failed(sc, rp, b); };
            Func<string, string, RemovePaymentCardResponse> forbidden = (rp, b) => { return new RemovePaymentCardResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);
        }



    }
}
