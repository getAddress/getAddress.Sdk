using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class GetExpandedAddressResponse : ResponseBase<GetExpandedAddressResponse.Success, GetExpandedAddressResponse.Failed>
    {

        protected GetExpandedAddressResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {


        }


        public class Success : GetExpandedAddressResponse
        {
            public IEnumerable<ExpandedAddress> Addresses { get; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string Postcode { get; set; }

            internal Success(int statusCode, string reasonPhase, string raw, double latitude, double longitude,string postcode, IEnumerable<ExpandedAddress> addresses) : base(statusCode, reasonPhase, raw, true)
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
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                this.FailedResult = this;
            }
        }
    }
}
