﻿using Newtonsoft.Json;


namespace getAddress.Sdk.Api.Requests
{
    public class CreateSubscriptionRequest
    {
        [JsonProperty("plan_name")]
        public string PlanName
        {
            get; set;
        }

    }
}
