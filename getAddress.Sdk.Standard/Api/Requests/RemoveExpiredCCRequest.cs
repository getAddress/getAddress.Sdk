using Newtonsoft.Json;
namespace getAddress.Sdk.Api.Requests
{
    public class RemoveExpiredCCRequest
    {
        [JsonProperty("id")]
        public long Id
        {
            get;
        }
        public RemoveExpiredCCRequest(long id)
        {
            Id = id;
        }

        public static implicit operator RemoveExpiredCCRequest(long id)
        {
            return new RemoveExpiredCCRequest(id);
        }
    }
}
