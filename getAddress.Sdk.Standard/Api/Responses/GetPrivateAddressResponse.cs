
namespace getAddress.Sdk.Api.Responses
{
    public class PrivateAddress: Address
    {
        public string Id { get; set; }
    }

    public class GetPrivateAddressResponse : ResponseBase<GetPrivateAddressResponse.Success,GetPrivateAddressResponse.Failed>
    {

        protected GetPrivateAddressResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {
        }

        public class Success : GetPrivateAddressResponse
        {
            public PrivateAddress PrivateAddress { get; }

            public Success(int statusCode, string reasonPhrase, string raw, PrivateAddress privateAddress) : base(statusCode, reasonPhrase, raw, true)
            {
                PrivateAddress = privateAddress;
                SuccessfulResult = this;
            }
            public Success(int statusCode, string reasonPhrase, string raw, string id,
                string line1, string line2, string line3, string line4, string locality, string townOrCity, string county) : this(statusCode, reasonPhrase, raw,
                    new PrivateAddress
                    {
                        Id = id,
                        Line1 = line1,
                        Line2 = line2,
                        Line3 = line3,
                        Line4 = line4,
                        Locality = locality,
                        TownOrCity = townOrCity,
                        County = county
                    })
            {
               
            }
        }

        public class Failed : GetPrivateAddressResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}
