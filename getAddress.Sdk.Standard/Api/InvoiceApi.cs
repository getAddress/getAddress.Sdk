using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class InvoiceApi: AdminApiBase
    {

        public const string Path = "invoices/";

        internal InvoiceApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey,api)
        {

        }


        public async Task<GetInvoiceResponse> Get(string number)
        {
            return await Get(Api, Path, AdminKey,number);
        }

        public async static Task<GetInvoiceResponse> Get(GetAddesssApi api, string path, 
            AdminKey adminKey,string number)
        {
            var fullPath = $"{path}{number}";

            return await GetInternal(api, fullPath, adminKey,number);
        }

           public async  Task<ListInvoicesResponse> List()
        {
            return await List(Api, Path, AdminKey);
        }

        public async static Task<ListInvoicesResponse> List(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var list = GetInvoiceList(body);

                return new ListInvoicesResponse.Success((int)response.StatusCode, response.ReasonPhrase, body,list);
            }

            return new ListInvoicesResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        private async static Task<GetInvoiceResponse> GetInternal(GetAddesssApi api, string path, AdminKey adminKey, string number)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));
            

            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var invoice = GetInvoice(body,number);

                return new GetInvoiceResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, invoice);
            }

            return new GetInvoiceResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
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
