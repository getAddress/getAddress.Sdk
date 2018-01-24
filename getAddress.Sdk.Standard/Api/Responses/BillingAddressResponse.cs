

namespace getAddress.Sdk.Api.Responses
{
    public abstract class BillingAddressResponse : ResponseBase<BillingAddressResponse.Success,BillingAddressResponse.Failed>
    {
        protected BillingAddressResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

        }

        public class Success : BillingAddressResponse
        {
            public string Line1 { get; set; }

            public string Line2 { get; set; }

            public string Line3 { get; set; }

            public string TownOrCity { get; set; }

            public string County { get; set; }

            public string Postcode { get; set; }


            internal Success(int statusCode, string reasonPhase, string raw, string line1, 
                string line2, string line3, string townOrCity, string county, string postcode) : base(statusCode, reasonPhase, raw, true)
            {
                Line1 = line1;
                Line2 = line2;
                Line3 = line3;
                TownOrCity = townOrCity;
                County = county;
                Postcode = postcode;
                SuccessfulResult = this;
            }
        }

        public class Failed : BillingAddressResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}
