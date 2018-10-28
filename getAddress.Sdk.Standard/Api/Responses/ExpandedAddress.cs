

namespace getAddress.Sdk.Api.Responses
{
    public class ExpandedAddress : Address
    {
        public FormattedAddress FormattedAddress { get; set; }
        public string Thoroughfare { get; set; }
        public string BuildingName { get; set; }  
        public string SubuildingName { get; set; }
        public string SubuildingNumber { get; set; }
        public string BuildingNumber { get; set; }
    }

}
