

namespace getAddress.Sdk.Api.Responses
{
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }
        public string Locality { get; set; }
        public string TownOrCity { get; set; }
        public string County { get; set; }
    }

    public class AddressAndId : Address
    {
        public string Id { get; set; }
    }
}
