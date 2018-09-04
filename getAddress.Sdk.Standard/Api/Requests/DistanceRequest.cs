namespace getAddress.Sdk.Api.Requests
{
    public class DistanceRequest
    {
        public string PostcodeFrom
        {
            get;
        }

        public string PostcodeTo
        {
            get;
        }

        public DistanceRequest(string postcodeFrom, string postcodeTo)
        {
            PostcodeFrom = postcodeFrom;
            PostcodeTo = postcodeTo;
        }
    }
}


   
