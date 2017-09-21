using getAddress.Sdk.Api.Responses;
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

        public async Task<UnsubscribeResponse> Unsubscribe()
        {
            return await Unsubscribe(Api, Path, AdminKey);
        }

        public async static Task<UnsubscribeResponse> Unsubscribe(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));

            api.SetAuthorizationKey(adminKey);

            var fullPath = path + "unsubscribe";

            var response = await api.Put(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                

                return new UnsubscribeResponse.Success((int)response.StatusCode, response.ReasonPhrase, body);
            }

            return new UnsubscribeResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }


    }
}
