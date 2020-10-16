using Newtonsoft.Json;


namespace getAddress.Sdk.Api.Requests
{
    public class UpdateDefaultPaymentCardRequest
    {
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }
        public UpdateDefaultPaymentCardRequest(string id)
        {
            Id = id;
        }

    }
}
