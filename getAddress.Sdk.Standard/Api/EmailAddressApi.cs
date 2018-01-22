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

            if (response.IsSuccessStatusCode)
            {
                var model = GetEmailAddress(body);

                return new EmailAddressResponse.Success((int)response.StatusCode, response.ReasonPhrase, body,model.EmailAddress );
            }

            return new EmailAddressResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
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

            if (response.IsSuccessStatusCode)
            {
                return new EmailAddressResponse.Success((int)response.StatusCode, response.ReasonPhrase, body,request.NewEmailAddress);
            }

            if(response.StatusCode == System.Net.HttpStatusCode.BadRequest){
                var message = GetMessage(body);
                return new EmailAddressResponse.FailedInvalidEmailAddress((int)response.StatusCode, response.ReasonPhrase, body,message);
            }

            return new EmailAddressResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
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
