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

            Func<int, string, string, AddInvoiceCCResponse> success = (statusCode, phrase, json) =>
            {
                var messageAndId = MessageAndId.GetMessageAndId(json);

                var id = long.Parse(messageAndId.Id);

                return new AddInvoiceCCResponse.Success(statusCode, phrase, json, messageAndId.Message, id);
            };

            Func<string, string, AddInvoiceCCResponse> tokenExpired = (rp, b) => { return new AddInvoiceCCResponse.TokenExpired(rp, b); };
            Func<string, string, int, AddInvoiceCCResponse> limitReached = (rp, b, r) => { return new AddInvoiceCCResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, AddInvoiceCCResponse> failed = (sc, rp, b) => { return new AddInvoiceCCResponse.Failed(sc, rp, b); };

            return response.GetResponse( body,
                success,
                tokenExpired,
                limitReached,
                failed);

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

            Func<int, string, string, RemoveInvoiceCCResponse> success = (statusCode, phrase, json) =>
            {
                var message = GetMessage(json);

                return new RemoveInvoiceCCResponse.Success(statusCode, phrase, json, message);
            };

            Func<string, string, RemoveInvoiceCCResponse> tokenExpired = (rp, b) => { return new RemoveInvoiceCCResponse.TokenExpired(rp, b); };
            Func<string, string, int, RemoveInvoiceCCResponse> limitReached = (rp, b, r) => { return new RemoveInvoiceCCResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, RemoveInvoiceCCResponse> failed = (sc, rp, b) => { return new RemoveInvoiceCCResponse.Failed(sc, rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed
                );

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

            Func<int, string, string, ListInvoiceCCResponse> success = (statusCode, phrase, json) =>
            {
                var list = GetInvoiceCCList(json);

                return new ListInvoiceCCResponse.Success(statusCode, phrase, json, list);
            };

            Func<string, string, ListInvoiceCCResponse> tokenExpired = (rp, b) => { return new ListInvoiceCCResponse.TokenExpired(rp, b); };
            Func<string, string, int, ListInvoiceCCResponse> limitReached = (rp, b, r) => { return new ListInvoiceCCResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, ListInvoiceCCResponse> failed = (sc, rp, b) => { return new ListInvoiceCCResponse.Failed(sc, rp, b); };

            return response.GetResponse(body,
                success,
                tokenExpired,
                limitReached,
                failed);
        }

        private async static Task<GetInvoiceCCResponse> GetCCInternal(GetAddesssApi api, string path, AdminKey adminKey, long id)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (adminKey == null) throw new ArgumentNullException(nameof(adminKey));


            api.SetAuthorizationKey(adminKey);

            var response = await api.Get(path);

            var body = await response.Content.ReadAsStringAsync();

            Func<int, string, string, GetInvoiceCCResponse> success = (statusCode, phrase, json) =>
            {
                var invoiceCC = GetCCInvoice(json);

                return new GetInvoiceCCResponse.Success(statusCode, phrase, json, invoiceCC);
            };

            Func<string, string, GetInvoiceCCResponse> tokenExpired = (rp, b) => { return new GetInvoiceCCResponse.TokenExpired(rp, b); };
            Func<string, string, int, GetInvoiceCCResponse> limitReached = (rp, b, r) => { return new GetInvoiceCCResponse.RateLimitedReached(rp, b, r); };
            Func<int, string, string, GetInvoiceCCResponse> failed = (sc, rp, b) => { return new GetInvoiceCCResponse.Failed(sc, rp, b); };

            return response.GetResponse( body,
                success,
                tokenExpired,
                limitReached,
                failed);

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
