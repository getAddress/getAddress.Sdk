using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{

    public class GetAddressResponse : ResponseBase<GetAddressResponse.Success,GetAddressResponse.Failed>
    {

        protected GetAddressResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {

            
        }


        public class Success : GetAddressResponse
        {
            public IEnumerable<Address> Addresses { get; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }

            internal Success(int statusCode, string reasonPhase, string raw, double latitude, double longitude, IEnumerable<Address> addresses) : base(statusCode, reasonPhase, raw, true)
            {
                Latitude = latitude;
                Longitude = longitude;
                Addresses = addresses;
                this.SuccessfulResult = this;
            }
        }

        public class Failed : GetAddressResponse//todo: failed class for each possible response  
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                this.FailedResult = this;
            }
        }
    }
}
