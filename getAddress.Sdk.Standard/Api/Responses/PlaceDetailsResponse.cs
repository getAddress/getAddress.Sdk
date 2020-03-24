namespace getAddress.Sdk.Api.Responses
{
    public class PlaceDetailsResponse : ResponseBase<PlaceDetailsResponse.Success, PlaceDetailsResponse.Failed, PlaceDetailsResponse.TokenExpired>
    {

        protected PlaceDetailsResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {
        }

        public class Success : PlaceDetailsResponse
        {
            public ExpandedAddress Address { get; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string Postcode { get; set; }

            public Success(int statusCode, string reasonPhrase, string raw, double latitude, double longitude, string postcode, ExpandedAddress address) : base(statusCode, reasonPhrase, raw, true)
            {
                Latitude = latitude;
                Longitude = longitude;
                Address = address;
                Postcode = postcode;
                this.SuccessfulResult = this;
            }
        }

        public class Failed : PlaceDetailsResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                this.FailedResult = this;
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
