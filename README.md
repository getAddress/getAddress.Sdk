# getAddress.io SDK

## Install

```
Install from Nuget:

PM> Install-Package getAddress.Sdk
```
## Usage

### Find addresses 

```
var apiKey = new ApiKey("<YOUR API KEY>");

using (var api = new GetAddesssApi(apiKey))
{
    var result = await api.Address.Get(new GetAddressRequest("POSTCODE", "OPTIONAL HOUSE NAME"));

    if (result.IsSuccess)
    {
        var successfulResult =  (GetAddressResponse.Success)result;

        var latitude = successfulResult.Latitude;

        var Longitude = successfulResult.Longitude;

        foreach (var address in successfulResult.Addresses)
        {
            var line1 = address.Line1;
            var line2 = address.Line2;
            var line3 = address.Line3;
            var line4 = address.Line4;
            var locality = address.Locality;
            var townOrCity = address.TownOrCity;
            var county = address.County;
        }
    }
}         
```
