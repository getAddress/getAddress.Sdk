using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Responses
{
    public class EmailNotification
    {
        internal static EmailNotification Blank(long id)
        {
            var emailNotification = new EmailNotification(id, string.Empty);
            return emailNotification;
        }
        internal EmailNotification()
        {

        }

        public EmailNotification(long id, string emailAddress)
        {

            Id = id;
            EmailAddress = emailAddress;
        }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("email-address")]
        public string EmailAddress { get; set; }


        internal static EmailNotification FromJson(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return Blank(0);

            return JsonConvert.DeserializeObject<EmailNotification>(body);
        }


    }
}


