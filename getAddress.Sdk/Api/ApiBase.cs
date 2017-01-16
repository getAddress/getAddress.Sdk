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

        protected class NameAndId: IdBase
        {
            
            public string Name { get; set; }
        }

        protected class ValueAndId: IdBase
        {
 
            public string Value { get; set; }
        }
       

        

        protected static AddressAndId[] GetAddressAndIds(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new AddressAndId[0];

            var jsons = JsonConvert.DeserializeObject<dynamic[]>(body);

            var addressList = new List<AddressAndId>();
            foreach (var json in jsons) {
                var addressAndId = new AddressAndId
                {
                    Id = json.id,
                    Line1 = json.line1,
                    Line2 = json.line2,
                    Line3 = json.line3,
                    Line4 = json.line4,
                    Locality = json.locality,
                    TownOrCity = json.townOrcity,
                    County = json.county

                };
                addressList.Add(addressAndId);
            }

            return addressList.ToArray();
        }

        protected static AddressAndId GetAddressAndId(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new AddressAndId();

            var json = JsonConvert.DeserializeObject<dynamic>(body);

            return new AddressAndId
            {
                Id = json.id,
                Line1 = json.line1,
                Line2 = json.line2,
                Line3 = json.line3,
                Line4 = json.line4,
                Locality = json.locality,
                TownOrCity = json.townOrcity,
                County = json.county

            };
        }

        protected static ValueAndId GetValueAndId(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new ValueAndId();

            var json = JsonConvert.DeserializeObject<dynamic>(body);

            return new ValueAndId
            {
                Id = json.id,
                Value = json.value
            };
        }

        protected static NameAndId GetNameAndId(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new NameAndId();

            var json = JsonConvert.DeserializeObject<dynamic>(body);

            return new NameAndId
            {
                Id = json.id,
                Name = json.name
            };
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
