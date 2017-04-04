using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace getAddress.Sdk.Api
{

    public abstract class AdminApiBase:ApiBase
    {
        public AdminKey AdminKey
        {
            get;
        }

        protected AdminApiBase(AdminKey adminKey, GetAddesssApi api):base(api)
        {
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey)); 

            AdminKey = adminKey;
        }

        protected class IdBase
        {
            public string Id { get; set; }
            
        }

        protected class MessageAndId: IdBase
        {
           
            public string Message { get; set; }
        }



        protected static MessageAndId GetMessageAndId(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new MessageAndId();

            var json = JsonConvert.DeserializeObject<dynamic>(body);

            return new MessageAndId
            {
                Id = json.id,
                Message = json.message
            };
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
