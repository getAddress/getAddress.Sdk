# getAddress.io SDK

## Install

```
Install from Nuget:

PM> Install-Package getAddress.Sdk
```
## Usage

### Find postal addresses for a UK postcode and optional house name/number 

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
### Get the current day's usage and usage limits
```
var adminKey = new AdminKey("Your Admin Key");

using (var api = new GetAddesssApi(adminKey))
{
    var result = await api.Usage.Get();

    if (result.IsSuccess)
    {
        var successfulResult = (GetUsageResponse.Success)result;

        var count = successfulResult.Usage.Count;

        var limit1 = successfulResult.Usage.Limit1;

        var limit2 = successfulResult.Usage.Limit2;
    }
}
```
### Get usage and limits for a given day, month and year 
```
 var adminKey = new AdminKey("Your Admin Key");

using (var api = new GetAddesssApi(adminKey))
{
    var result = await api.Usage.Get(DAY,MONTH,YEAR);

    if (result.IsSuccess)
    {
        var successfulResult = (GetUsageResponse.Success)result;

        var count = successfulResult.Usage.Count;

        var limit1 = successfulResult.Usage.Limit1;

        var limit2 = successfulResult.Usage.Limit2;
    }
}
```
