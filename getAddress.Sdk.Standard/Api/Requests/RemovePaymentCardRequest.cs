using Newtonsoft.Json;


namespace getAddress.Sdk.Api.Requests
{
    public class RemovePaymentCardRequest
    {
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }
        public RemovePaymentCardRequest(string id)
        {
            Id = id;
        }


    }
}
