using getAddress.Api;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public class InvoiceCCApi : AdminApiBase
    {
        public const string Path = "cc/invoices/";

        internal InvoiceCCApi(AdminKey adminKey, GetAddesssApi api) : base(adminKey, api)
        {

        }

        public async Task<GetInvoiceCCResponse> Get(GetInvoiceCCRequest request)
        {
            return await Get(Api, Path, AdminKey, request);
        }

        public async static Task<GetInvoiceCCResponse> Get(GetAddesssApi api, string path,
           AdminKey adminKey, GetInvoiceCCRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var fullPath = $"{path}{request.Id}";

            return await GetCCInternal(api, fullPath, adminKey, request.Id);
        }

        public async Task<AddInvoiceCCResponse> Add(AddInvoiceCCRequest request)
        {
            return await Add(Api, request, Path, AdminKey);
        }

        public async static Task<AddInvoiceCCResponse> Add(GetAddesssApi api, AddInvoiceCCRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Post(path, request);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var messageAndId = MessageAndId.GetMessageAndId(body);

                var id = long.Parse(messageAndId.Id);

                return new AddInvoiceCCResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, messageAndId.Message, id);
            }
            else if (response.HasTokenExpired())
            {
                return new AddInvoiceCCResponse.TokenExpired(response.ReasonPhrase, body);
            }

            return new AddInvoiceCCResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        public async Task<RemoveInvoiceCCResponse> Remove(RemoveInvoiceCCRequest request)
        {
            return await Remove(Api, request, Path, AdminKey);
        }

        public async static Task<RemoveInvoiceCCResponse> Remove(GetAddesssApi api, RemoveInvoiceCCRequest request, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (path == null) throw new ArgumentNullException(nameof(path));

            var fullPath = path + request.Id;

            api.SetAuthorizationKey(adminKey);

            var response = await api.Delete(fullPath);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var message = GetMessage(body);

                return new RemoveInvoiceCCResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, message);
            }
            else if (response.HasTokenExpired())
            {
                return new RemoveInvoiceCCResponse.TokenExpired(response.ReasonPhrase, body);
            }

            return new RemoveInvoiceCCResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        public async Task<ListInvoiceCCResponse> List()
        {
            return await List(Api, Path, AdminKey);
        }

        public async static Task<ListInvoiceCCResponse> List(GetAddesssApi api, string path, AdminKey adminKey)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));

            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var list = GetInvoiceCCList(body);

                return new ListInvoiceCCResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, list);
            }
            else if (response.HasTokenExpired())
            {
                return new ListInvoiceCCResponse.TokenExpired(response.ReasonPhrase, body);
            }

            return new ListInvoiceCCResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }

        private async static Task<GetInvoiceCCResponse> GetCCInternal(GetAddesssApi api, string path, AdminKey adminKey, long id)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));


            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var invoiceCC = GetCCInvoice(body);

                return new GetInvoiceCCResponse.Success((int)response.StatusCode, response.ReasonPhrase, body, invoiceCC);
            }
            else if (response.HasTokenExpired())
            {
                return new GetInvoiceCCResponse.TokenExpired(response.ReasonPhrase, body);
            }

            return new GetInvoiceCCResponse.Failed((int)response.StatusCode, response.ReasonPhrase, body);
        }
       
        private static IEnumerable<InvoiceCC> GetInvoiceCCList(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return new List<InvoiceCC>();

            var json = JsonConvert.DeserializeObject<JArray>(body);

            var list = new List<InvoiceCC>();

            foreach (var token in json)
            {
                var invoice = token.ToObject<InvoiceCC>(); 

                if (invoice.Id != 0) list.Add(invoice);
            }

            return list;
        }

        private static InvoiceCC GetCCInvoice(string body)
        {
            if (string.IsNullOrWhiteSpace(body)) return InvoiceCC.Blank(0);

            return JsonConvert.DeserializeObject<InvoiceCC>(body);
        }

        


    }
}
