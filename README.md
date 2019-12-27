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

IAddressService addressService = new AddressService(apiKey);

var result = await addressService.Get(new GetAddressRequest("POSTCODE", "OPTIONAL HOUSE NAME"));

if (result.IsSuccess)
{
    var successfulResult = result.SuccessfulResult;

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
```
### Get the current day's usage and usage limits
```
var adminKey = new AdminKey("<YOUR ADMINISTRATION KEY>");

IUsageService usageService = new UsageService(adminKey);

var result = await usageService.GetV3();

if (result.IsSuccess)
{
    var successfulResult = result.SuccessfulResult;

    var usageToday = successfulResult.Usage.UsageToday;

    var dailyLimit = successfulResult.Usage.DailyLimit;

    var monthlyBuffer = successfulResult.Usage.MonthlyBuffer;

    var monthlyBufferUsed = successfulResult.Usage.MonthlyBufferUsed;
}
```
### Get usage and limits for a given day, month and year 
```
var adminKey = new AdminKey("<YOUR ADMINISTRATION KEY>");

IUsageService usageService = new UsageService(adminKey);

var result = await usageService.GetV3(new GetUsageRequest(DAY,MONTH,YEAR));

if (result.IsSuccess)
{
    var successfulResult = result.SuccessfulResult;

    var usageToday = successfulResult.Usage.UsageToday;

    var dailyLimit = successfulResult.Usage.DailyLimit;

    var monthlyBuffer = successfulResult.Usage.MonthlyBuffer;

    var monthlyBufferUsed = successfulResult.Usage.MonthlyBufferUsed;
}
```
