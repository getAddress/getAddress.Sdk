using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace getAddress.Sdk.Api
{
    public abstract class ApiKeyBase : ApiBase
    {
        public ApiKey ApiKey
        {
            get;
        }

        protected ApiKeyBase(ApiKey apiKey, GetAddesssApi api) : base(api)
        {
            if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));

            ApiKey = apiKey;
        }
    }

     public abstract class AdminApiBase:ApiBase
    {
        public AdminKey AdminKey
        {
            get;
        }

        protected AdminApiBase(AdminKey adminKey, GetAddesssApi api):base(api)
        {
            AdminKey = adminKey;
        }

       

        protected static string GetMessage(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return string.Empty;

            var json = JsonConvert.DeserializeObject<dynamic>(body);

            return json.message ?? json.Message;
        }
    }

     public abstract class ApiBase
    {
        protected readonly GetAddesssApi Api;

        protected ApiBase(GetAddesssApi api)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));

            Api = api;
        }


        
    }
}
