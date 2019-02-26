using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class ExpiredCC
    {
        internal static ExpiredCC Blank(long id)
        {
            var cc = new ExpiredCC(id, string.Empty);
            return cc;
        }
        internal ExpiredCC()
        {

        }
        internal ExpiredCC(long id, string emailAddress)
        {

            Id = id;
            EmailAddress = emailAddress;
        }
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }

        public static ExpiredCC Deserialize(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return ExpiredCC.Blank(0);

            return JsonConvert.DeserializeObject<ExpiredCC>(body);
        }

        public static IEnumerable<ExpiredCC> DeserializeToList(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new List<ExpiredCC>();

            var json = JsonConvert.DeserializeObject<JArray>(body);

            var list = new List<ExpiredCC>();

            foreach (var token in json)
            {
                var cc = token.ToObject<ExpiredCC>();

                if (cc.Id != 0) list.Add(cc);
            }

            return list;
        }
    }

}


