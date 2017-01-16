
namespace getAddress.Sdk.Api.Responses
{
    public class GetPrivateAddressResponse : AdminResponse
    {

        protected GetPrivateAddressResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {
        }

        public class Success : GetPrivateAddressResponse
        {
            public string Id { get; }
            public string Line1 { get; }
            public string Line2 { get; }
            public string Line3 { get; }
            public string Line4 { get; }
            public string Locality { get; }
            public string TownOrCity { get; }
            public string County { get; }


            internal Success(int statusCode, string reasonPhase, string raw, string id,
                string line1,string line2, string line3, string line4,string locality, string townOrCity, string county) : base(statusCode, reasonPhase, raw, true)
            {
                Id = id;
                Line1 = line1;
                Line2 = line2;
                Line3 = line3;
                Line4 = line4;
                Locality = locality;
                TownOrCity = townOrCity;
                County = county;
            }
        }

        public class Failed : GetPrivateAddressResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {

            }
        }
    }
}
