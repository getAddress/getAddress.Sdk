using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Net.Http;

namespace getAddress.Sdk.Tests
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public async Task ListInvoices()
        {
            var adminKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new AdminKey(adminKey),httpClient))
            {
                var now = DateTime.Now;
                var toDay = now.Day;
                var toMonth = now.Month;
                var toYear = now.Year;

                var lastWeek = now.AddDays(-7);
                var fromDay = lastWeek.Day;
                var fromMonth = lastWeek.Month;
                var fromYear = lastWeek.Year;

                var result = await api.Invoices.List(new Api.Requests.ListInvoicesRequest(fromDay, fromMonth, fromYear, toDay, toMonth, toYear));

                Assert.IsTrue(result.IsSuccess);
            }

        }

        [TestMethod]
        public async Task ListUsages()
        {
            var adminKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new AdminKey(adminKey),httpClient))
            {
                var now = DateTime.Now;
                var toDay = now.Day;
                var toMonth = now.Month;
                var toYear = now.Year;

                var lastWeek = now.AddDays(-7);
                var fromDay = lastWeek.Day;
                var fromMonth = lastWeek.Month;
                var fromYear = lastWeek.Year;

                var result = await api.Usage.List(new Api.Requests.ListUsageRequest(fromDay, fromMonth, fromYear, toDay, toMonth, toYear));

                Assert.IsTrue(result.IsSuccess);
            }

        }

        [TestMethod]
        public async Task ListDomains()
        {
            var adminKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new AdminKey(adminKey),httpClient))
            {
                var result = await api.DomainWhitelist.List();

                Assert.IsTrue(result.IsSuccess);
            }
             
        }

        [TestMethod]
        public async Task ListIpAddress()
        {
            var adminKey = KeyHelper.GetAdminKey();

            var httpClient = new HttpClient();

            httpClient.BaseAddress = UrlHelper.GetStagingUri();

            using (var api = new GetAddesssApi(new AdminKey(adminKey),httpClient))
            {
                var result = await api.IpAddressWhitelist.List();

                Assert.IsTrue(result.IsSuccess);
            }

        }
    }
}
