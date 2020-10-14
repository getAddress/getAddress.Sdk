using Newtonsoft.Json;


namespace getAddress.Sdk.Api.Requests
{
    public class AddPaymentCardRequest
    {
        [JsonProperty("token")]
        public string Token
        {
            get;
            set;
        }
        public AddPaymentCardRequest(string token)
        {
            Token = token;
        }

       
    }
}
