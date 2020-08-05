using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class InvoiceApi: AdminApiBase
    {
        public const string Path = "invoices/";

        internal InvoiceApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey,api)
        {

        }

        public async Task<GetInvoiceResponse> Get(GetInvoiceRequest request)
        {
            return await Get(Api, Path, AdminKey,request);
        }

        public async static Task<GetInvoiceResponse> Get(GetAddesssApi api, string path, 
            AdminKey adminKey, GetInvoiceRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var fullPath = $"{path}{request.Number}";

            return await GetInternal(api, fullPath, adminKey,request.Number);
        }

        public async Task<ListInvoicesResponse> List()
        {
            return await List(Api, Path, AdminKey);
        }

        public async Task<ListInvoicesResponse> List(ListInvoicesRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var fullPath = $"{Path}from/{request.From.Day}/{request.From.Month}/{request.From.Year}/To/{request.To.Day}/{request.To.Month}/{request.To.Year}";

            return await List(Api, fullPath, AdminKey);
        }

        public async static Task<ListInvoicesResponse> List(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));

            api.SetAuthorizationKey(adminKey);

            var response = await api.HttpGet(path);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, ListInvoicesResponse> success = (statusCode, phrase, json) =>
            {
                var list = GetInvoiceList(json);

                return new ListInvoicesResponse.Success(statusCode,phrase, json, list);
            };

            Func<string, string, ListInvoicesResponse> tokenExpired = (rp, b) => { return new ListInvoicesResponse.TokenExpired(rp, b); };
            Func<string, string, double, ListInvoicesResponse> limitReached = (rp, b, r) => { return new ListInvoicesResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, ListInvoicesResponse> failed = (sc, rp, b) => { return new ListInvoicesResponse.Failed(sc, rp, b); };
            Func<string, string, ListInvoicesResponse> forbidden = (rp, b) => { return new ListInvoicesResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);

        }

       

        private async static Task<GetInvoiceResponse> GetInternal(GetAddesssApi api, string path, AdminKey adminKey, string number)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));
            
            api.SetAuthorizationKey(adminKey);

            var response = await api.HttpGet(path);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, GetInvoiceResponse> success = (statusCode, phrase, json) =>
            {
                var invoice = GetInvoice(json, number);

                return new GetInvoiceResponse.Success(statusCode, phrase, json, invoice);
            };

            Func<string, string, GetInvoiceResponse> tokenExpired = (rp, b) => { return new GetInvoiceResponse.TokenExpired(rp, b); };
            Func<string, string, double, GetInvoiceResponse> limitReached = (rp, b, r) => { return new GetInvoiceResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, GetInvoiceResponse> failed = (sc, rp, b) => { return new GetInvoiceResponse.Failed(sc, rp, b); };
            Func<string, string, GetInvoiceResponse> forbidden = (rp, b) => { return new GetInvoiceResponse.Forbidden(rp, b); };


            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed,
                forbidden);
        }

        private static IEnumerable<Invoice> GetInvoiceList(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new List<Invoice>();

            var json = JsonConvert.DeserializeObject<JArray>(body);

            var list = new List<Invoice>();

            foreach (dynamic i in json)
            {
                var invoice = GetInvoice(i);

                list.Add(invoice);
            }

            return list;
        }

        private static Invoice GetInvoice(string body, string number)
        {
            if (string.IsNullOrWhiteSpace(body) || string.IsNullOrWhiteSpace(number)) return  Invoice.Blank(number);

            var json = JsonConvert.DeserializeObject<dynamic>(body);

            return GetInvoice(json);
        }

        private static Invoice GetInvoice(dynamic json)
        {
            if (json is JArray) return null;


            var address = new InvoiceAddress((string)json.address_1, (string)json.address_2, 
                (string)json.address_3, (string)json.address_4, (string)json.address_5, (string)json.address_6);

            var invoice =  new Invoice((DateTime)json.date,(string)json.number,(decimal)json.total,
               (decimal) json.tax,(string)json.pdf_url,address);
            
            foreach(var iL in json.invoice_lines){

                var invoiceLine = new InvoiceLine((int)iL.quantity,(string) iL.details,(decimal) iL.unit_price,(decimal) iL.subtotal);
                invoice.AddLine(invoiceLine);
            }

            return invoice;
        }

    }
}
