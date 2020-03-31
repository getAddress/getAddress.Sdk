using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class EmailAddressApi: AdminApiBase
    {
        public const string Path = "email-address/";

        internal EmailAddressApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey,api)
        {

        }

        public async Task<EmailAddressResponse> Get()
        {
            return await Get(Api, Path, this.AdminKey);
        }

        public async static Task<EmailAddressResponse> Get(GetAddesssApi api, string path, AdminKey apiKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));

            api.SetAuthorizationKey(apiKey);

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, EmailAddressResponse> success = (statusCode, phrase, json) =>
            {
                var model = GetEmailAddress(json);

                return new EmailAddressResponse.Success(statusCode, phrase, json, model.EmailAddress);
            };

            Func<string, string, EmailAddressResponse> tokenExpired = (rp, b) => { return new EmailAddressResponse.TokenExpired(rp, b); };
            Func<string, string, int, EmailAddressResponse> limitReached = (rp, b, r) => { return new EmailAddressResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, EmailAddressResponse> failed = (sc, rp, b) => { return new EmailAddressResponse.Failed(sc, rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed
                );

        }

        public async Task<EmailAddressResponse> Update(UpdateEmailAddressRequest request)
        {
            return await Update(Api, Path, this.AdminKey,request);
        }

        public async static Task<EmailAddressResponse> Update(GetAddesssApi api, string path, AdminKey adminKey,UpdateEmailAddressRequest request)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
          
            api.SetAuthorizationKey(adminKey);

            var response = await api.Put(path,request);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, EmailAddressResponse> success = (statusCode, phrase, json) =>
            {
                return new EmailAddressResponse.Success(statusCode, phrase, json, request.NewEmailAddress);
            };

            Func<string, string, EmailAddressResponse> tokenExpired = (rp, b) => { return new EmailAddressResponse.TokenExpired(rp, b); };
            Func<string, string, int, EmailAddressResponse> limitReached = (rp, b, r) => { return new EmailAddressResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, EmailAddressResponse> failed = (sc, rp, b) => { return new EmailAddressResponse.Failed(sc, rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed
                );

        }


        private static EmailAddressModel GetEmailAddress(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new EmailAddressModel();

            return JsonConvert.DeserializeObject<EmailAddressModel>(body);
        }

       


        private class EmailAddressModel
        {
            [JsonProperty("email-address")]
            public string EmailAddress { get; set; }
        }


    }
}
