using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Requests
{
    public class GetSecondLimitReachedRequest
    {

        [JsonProperty("id")]
        public int Id
        {
            get;
        }

        public GetSecondLimitReachedRequest(int id)
        {
            Id = id;
        }

        public static implicit operator GetSecondLimitReachedRequest(int id)
        {
            return new GetSecondLimitReachedRequest(id);
        }
    }
}
