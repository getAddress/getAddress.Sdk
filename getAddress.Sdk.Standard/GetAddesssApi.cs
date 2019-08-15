using getAddress.Sdk.Api;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace getAddress.Sdk
{

    public class GetAddressApi: GetAddesssApi
    {
        public GetAddressApi(ApiKey apiKey, HttpClient httpClient = null): base(apiKey, new AdminKey(string.Empty), httpClient)
        {
        }

        public GetAddressApi(AdminKey adminKey, HttpClient httpClient = null): base(new ApiKey(string.Empty), adminKey, httpClient)
        {
        }
    }

    public class GetAddesssApi:IDisposable
    {
        public Uri _baseAddress = new Uri("https://api.getaddress.io");
        private readonly HttpClient _client;

        public GetAddesssApi(ApiKey apiKey, HttpClient httpClient = null) : this(apiKey, new AdminKey(string.Empty), httpClient)
        {
        }

        public GetAddesssApi(AdminKey adminKey, HttpClient httpClient = null):this(new ApiKey(string.Empty),adminKey,httpClient)
        {
        }

        public GetAddesssApi(ApiKey apiKey, AdminKey adminKey, HttpClient httpClient = null)
        {
            _client = httpClient ?? GetHttpClient(_baseAddress);

            if(httpClient.BaseAddress == null)
            {
                httpClient.BaseAddress = _baseAddress;
            }

            AdminKey = adminKey;

            ApiKey = apiKey;

            DomainWhitelist = new DomainWhitelistApi(AdminKey, this);

            IpAddressWhitelist = new IpAddressWhitelistApi(AdminKey, this);

            PrivateAddress = new PrivateAddressApi(AdminKey, this);

            Usage = new UsageApi(AdminKey, this);

            BillingAddress = new BillingAddressApi(AdminKey, this);

            Address = new AddressApi(ApiKey, this);

            FirstLimitReachedWebhook = new FirstLimitReachedWebhookApi(AdminKey, this);

            SecondLimitReachedWebhook = new SecondLimitReachedWebhookApi(AdminKey, this);

            PaymentFailedWebhook = new PaymentFailedWebhookApi(AdminKey, this);

            ExpiredWebhook = new ExpiredWebhookApi(AdminKey, this);

            Subscription = new SubscriptionApi(adminKey, this);

            ApiKeyApi = new ApiKeyApi(adminKey, this);

            EmailAddress = new EmailAddressApi(adminKey, this);

            Invoices = new InvoiceApi(adminKey, this);

            InvoiceCC = new InvoiceCCApi(adminKey, this);

            Distance = new DistanceApi(apiKey, this);

            ExpiredCC = new ExpiredCCApi(adminKey, this);
        }

        public Uri BaseAddress
        {
            get
            {
                return _baseAddress;
            }
            set
            {
                _baseAddress = value;

                if (_client != null)
                {
                    _client.BaseAddress = _baseAddress;
                }
            }
        }

        public ApiKeyApi ApiKeyApi
        {
            get;
        }

         public InvoiceApi Invoices
        {
            get;
        }

        public DistanceApi Distance
        {
            get;
        }


        public InvoiceCCApi InvoiceCC
        {
            get;
        }

        public ExpiredCCApi ExpiredCC
        {
            get;
        }

        public EmailAddressApi EmailAddress { get; }

        public SubscriptionApi Subscription
        { get; }

        public ApiKey ApiKey
        {
            get;
        }

        public AdminKey AdminKey
        {
            get;
        }

        public SecondLimitReachedWebhookApi SecondLimitReachedWebhook
        {
            get;
        }

        public PaymentFailedWebhookApi PaymentFailedWebhook
        {
            get;
        }

        public ExpiredWebhookApi ExpiredWebhook
        {
            get;
        }

        public FirstLimitReachedWebhookApi FirstLimitReachedWebhook
        {
            get;
        }

        public BillingAddressApi BillingAddress
        {
            get;
        }

        public PrivateAddressApi PrivateAddress
        {
            get;
        }

        public DomainWhitelistApi DomainWhitelist
        {
            get;
        }

        public IpAddressWhitelistApi IpAddressWhitelist
        {
            get;
        }

        public UsageApi Usage
        {
            get;
        }

        public AddressApi Address
        {
            get;
        }

        internal  void SetAuthorizationKey(Key key)
        {
            SetAuthorizationKey(_client, key);
        }


        internal static void SetAuthorizationKey(HttpClient client, Key key)
        {
            if (!string.IsNullOrWhiteSpace(key.Value))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("api-key", key.Value);
            }
        }

        internal  async Task<HttpResponseMessage> Post(string path, object entity = null)
        {
            return await Post(_client, path, entity);
        }

        internal static async Task<HttpResponseMessage> Post(HttpClient client, string path, object entity = null)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (path == null) throw new ArgumentNullException(nameof(path));

            HttpContent httpContent = GetHttpContent(client, entity);

            return await client.PostAsync(path, httpContent);
        }

        internal async Task<HttpResponseMessage> Put(string path, object entity = null)
        {
            return await Put(_client, path, entity);
        }

        internal static async Task<HttpResponseMessage> Put(HttpClient client, string path, object entity = null)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (path == null) throw new ArgumentNullException(nameof(path));
            
            HttpContent httpContent = GetHttpContent(client, entity);

            return await client.PutAsync(path, httpContent);
        }

        private static  HttpContent GetHttpContent(HttpClient client, object entity = null)
        {
            entity = entity ?? string.Empty;

            var jsonString = JsonConvert.SerializeObject(entity);
            HttpContent httpContent = new StringContent(jsonString);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return httpContent;
        }

        internal  async Task<HttpResponseMessage> Delete(string path)
        {
            return await Delete(_client, path);
        }
        internal static async Task<HttpResponseMessage> Delete(HttpClient client, string path)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (path == null) throw new ArgumentNullException(nameof(path));

            return await client.DeleteAsync(path);
        }

        internal  async Task<HttpResponseMessage> Get(string path)
        {
            return await Get(_client, path);
        }
        internal static async Task<HttpResponseMessage> Get(HttpClient client, string path)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (path == null) throw new ArgumentNullException(nameof(path));

            return await client.GetAsync(path);
        }

        internal T Deserialize<T>(string json)
        {
            var settings = new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            };

            return JsonConvert.DeserializeObject<T>(json, settings);
        }

        private static HttpClient GetHttpClient(Uri baseAddress)
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = baseAddress;

            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

            return httpClient;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
