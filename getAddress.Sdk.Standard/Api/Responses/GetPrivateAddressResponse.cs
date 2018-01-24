
namespace getAddress.Sdk.Api.Responses
{
    public class PrivateAddress: Address
    {
        public string Id { get; set; }
    }

    public class GetPrivateAddressResponse : ResponseBase<GetPrivateAddressResponse.Success,GetPrivateAddressResponse.Failed>
    {

        protected GetPrivateAddressResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {
        }

        public class Success : GetPrivateAddressResponse
        {
            public PrivateAddress PrivateAddress { get; }


            internal Success(int statusCode, string reasonPhase, string raw, string id,
                string line1, string line2, string line3, string line4, string locality, string townOrCity, string county) : base(statusCode, reasonPhase, raw, true)
            {
                PrivateAddress = new PrivateAddress
                {
                    Id = id,
                    Line1 = line1,
                    Line2 = line2,
                    Line3 = line3,
                    Line4 = line4,
                    Locality = locality,
                    TownOrCity = townOrCity,
                    County = county
                };
                SuccessfulResult = this;
            }
        }

        public class Failed : GetPrivateAddressResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}
