using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Requests
{

    public class GetFirstLimitReachedRequest
    {
       
        [JsonProperty("id")]
        public int Id
        {
            get;
        }

        public GetFirstLimitReachedRequest( int id)
        {
            Id = id;
        }

        public static implicit operator GetFirstLimitReachedRequest(int id)
        {
            return new GetFirstLimitReachedRequest(id);
        }

    }
}
