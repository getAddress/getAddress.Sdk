

namespace getAddress.Sdk.Api.Responses
{

    public abstract class BillingAddressResponse : ResponseBase<BillingAddressResponse.Success,BillingAddressResponse.Failed,BillingAddressResponse.TokenExpired>
    {
        protected BillingAddressResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
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


            public Success(int statusCode, string reasonPhrase, string raw, string line1, 
                string line2, string line3, string townOrCity, string county, string postcode) : base(statusCode, reasonPhrase, raw, true)
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
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                   FailedResult = this;
            }
        }

        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                FailedResult = this;
                TokenExpiredResult = this;
            }
        }
    }
}
