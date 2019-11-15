namespace getAddress.Sdk.Api
{
    public class GooglePlaceId
    {
        public string Value { get; internal set; }

        internal GooglePlaceId()
        {

        }
        public GooglePlaceId(string value)
        {
            Value = value;
        }
    }
}
