using Newtonsoft.Json;


namespace getAddress.Sdk.Api.Requests
{
    public class GetExpiredCCRequest
    {
        public GetExpiredCCRequest(long id)
        {
            Id = id;
        }

        [JsonProperty("id")]
        public long Id { get; }

        public static implicit operator GetExpiredCCRequest(long id)
        {
            return new GetExpiredCCRequest(id);
        }
    }
}
