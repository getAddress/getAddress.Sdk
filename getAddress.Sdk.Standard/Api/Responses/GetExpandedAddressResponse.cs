using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class GetExpandedAddressResponse : ResponseBase<GetExpandedAddressResponse.Success, GetExpandedAddressResponse.Failed>
    {

        protected GetExpandedAddressResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {


        }


        public class Success : GetExpandedAddressResponse
        {
            public IEnumerable<ExpandedAddress> Addresses { get; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string Postcode { get; set; }

            internal Success(int statusCode, string reasonPhrase, string raw, double latitude, double longitude,string postcode, IEnumerable<ExpandedAddress> addresses) : base(statusCode, reasonPhrase, raw, true)
            {
                Latitude = latitude;
                Longitude = longitude;
                Addresses = addresses;
                Postcode = postcode;
                this.SuccessfulResult = this;
            }
        }

        public class Failed : GetExpandedAddressResponse//todo: failed class for each possible response  
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                this.FailedResult = this;
            }
        }
    }

}
