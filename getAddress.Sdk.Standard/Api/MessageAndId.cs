using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace getAddress.Api
{
    internal class IdBase
    {
        public string Id { get; set; }

    }

    internal class MessageAndId : IdBase
    {
        public string Message { get; set; }

        internal static MessageAndId GetMessageAndId(string body)
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
    internal class MessageResponse 
    {
        public string Message { get; set; }

        internal static MessageResponse GetMessageResponse(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new MessageResponse();

            var json = JsonConvert.DeserializeObject<dynamic>(body);

            return new MessageResponse
            {
                Message = json.message
            };
        }
    }


}
