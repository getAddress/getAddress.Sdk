using Newtonsoft.Json;


namespace getAddress.Sdk.Api.Requests
{
    public class ChangePlanSubscriptionRequest
    {
        [JsonProperty("plan_name")]
        public string PlanName
        {
            get; set;
        }

        [JsonProperty("card_id")]
        public string CardId
        {
            get; set;
        }
    }
}
