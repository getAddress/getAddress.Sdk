

namespace getAddress.Sdk.Api.Responses
{
    public abstract class GetIpAddressWhitelistResponse: AdminResponse
    {

        protected GetIpAddressWhitelistResponse(int statusCode, string reasonPhase, string raw, bool isSuccess):base(statusCode,reasonPhase,raw,isSuccess)
        {

        }

        public class Success: GetIpAddressWhitelistResponse
        {
            public string Id { get; set; }

            public string Value { get; set; }

            internal Success(int statusCode, string reasonPhase, string raw,string id, string value):base(statusCode, reasonPhase, raw,true)
            {
                Id = id;
                Value = value;
            }
        }

        public class Failed : GetIpAddressWhitelistResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) :base(statusCode, reasonPhase, raw, false)
            {

            }
        }
    }
}
