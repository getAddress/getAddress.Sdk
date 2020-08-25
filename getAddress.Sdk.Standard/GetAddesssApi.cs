using getAddress.Sdk.Api;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace getAddress.Sdk
{

    public class GetAddressApi : GetAddesssApi
    {
        public GetAddressApi(ApiKey apiKey, HttpClient httpClient = null) : base(apiKey, new AdminKey(string.Empty), httpClient)
        {
        }

        public GetAddressApi(AdminKey adminKey, HttpClient httpClient = null) : base(new ApiKey(string.Empty), adminKey, httpClient)
        {
        }

        public GetAddressApi(AccessToken accessToken,  HttpClient httpClient = null) : base(accessToken, httpClient)
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

        public GetAddesssApi(AccessToken accessToken,  HttpClient httpClient = null) : this(new ApiKey(string.Empty), new AdminKey(string.Empty), httpClient)
        {
            AccessToken = accessToken;
        }

        public GetAddesssApi(ApiKey apiKey, AdminKey adminKey, HttpClient httpClient = null)
        {
            _client = httpClient ?? GetHttpClient(_baseAddress);

            if(_client.BaseAddress == null)
            {
                _client.BaseAddress = _baseAddress;
            }

            if (!_client.DefaultRequestHeaders.Contains("api-version"))
            {
                _client.DefaultRequestHeaders.TryAddWithoutValidation("api-version", "2020-07-01");
            }

            AdminKey = adminKey;

            ApiKey = apiKey;

            domainWhitelist = new Lazy<DomainWhitelistApi>(() => new DomainWhitelistApi(adminKey, this));

            ipAddressWhitelist = new Lazy<IpAddressWhitelistApi>(() => new IpAddressWhitelistApi(adminKey, this));

            privateAddress = new Lazy<PrivateAddressApi>(() => new PrivateAddressApi(adminKey, this));

            usage = new Lazy<UsageApi>(() => new UsageApi(adminKey, this));

            billingAddress = new Lazy<BillingAddressApi>(() => new BillingAddressApi(adminKey, this));

            address = new Lazy<AddressApi>(() => new AddressApi(apiKey, this));

            firstLimitReachedWebhook = new Lazy<FirstLimitReachedWebhookApi>(() => new FirstLimitReachedWebhookApi(adminKey, this));

            secondLimitReachedWebhook = new Lazy<SecondLimitReachedWebhookApi>(() => new SecondLimitReachedWebhookApi(adminKey, this));

            paymentFailedWebhook = new Lazy<PaymentFailedWebhookApi>(() => new PaymentFailedWebhookApi(adminKey, this));

            expiredWebhook = new Lazy<ExpiredWebhookApi>(() => new ExpiredWebhookApi(adminKey, this));

            trackWebhook = new Lazy<TrackWebhookApi>(() => new TrackWebhookApi(adminKey, this));

            subscription = new Lazy<SubscriptionApi>(() => new SubscriptionApi(adminKey, this));

            apiKeyApi = new Lazy<ApiKeyApi>(() => new ApiKeyApi(adminKey, this));

            emailAddress = new Lazy<EmailAddressApi>(() => new EmailAddressApi(adminKey, this));

            invoices = new Lazy<InvoiceApi>(() => new InvoiceApi(adminKey, this));

            invoiceCC = new Lazy<InvoiceCCApi>(() => new InvoiceCCApi(adminKey, this));

            distance = new Lazy<DistanceApi>(() => new DistanceApi(apiKey, this));

            expiredCC = new Lazy<ExpiredCCApi>(() => new ExpiredCCApi(adminKey, this));

            permission = new Lazy<PermissionApi>(() => new PermissionApi(adminKey, this));

            autocomplete = new Lazy<AutocompleteApi>(() =>new AutocompleteApi(apiKey, this));

            token = new Lazy<TokenApi>(() => new TokenApi(adminKey, this));

            typeahead = new Lazy<TypeaheadApi>(() => new TypeaheadApi(apiKey, this));

            suggest = new Lazy<SuggestApi>(() => new SuggestApi(apiKey, this));

            get = new Lazy<GetApi>(() => new GetApi(apiKey, this));

            suggestLimitReachedWebhook = new Lazy<SuggestLimitReachedWebhookApi>(() => new SuggestLimitReachedWebhookApi(adminKey, this));
        }

        private Lazy<AutocompleteApi> autocomplete;
        private Lazy<PermissionApi> permission;
        private Lazy<ExpiredCCApi> expiredCC;
        private Lazy<DistanceApi> distance;
        private Lazy<InvoiceCCApi> invoiceCC;
        private Lazy<InvoiceApi> invoices;
        private Lazy<EmailAddressApi> emailAddress;
        private Lazy<ApiKeyApi> apiKeyApi;
        private Lazy<SubscriptionApi> subscription;
        private Lazy<ExpiredWebhookApi> expiredWebhook;
        private Lazy<TrackWebhookApi> trackWebhook;
        private Lazy<PaymentFailedWebhookApi> paymentFailedWebhook;
        private Lazy<SecondLimitReachedWebhookApi> secondLimitReachedWebhook;
        private Lazy<FirstLimitReachedWebhookApi> firstLimitReachedWebhook;
        private Lazy<AddressApi> address;
        private Lazy<UsageApi> usage;
        private Lazy<PrivateAddressApi> privateAddress;
        private Lazy<IpAddressWhitelistApi> ipAddressWhitelist;
        private Lazy<DomainWhitelistApi> domainWhitelist;
        private Lazy<BillingAddressApi> billingAddress;
        private Lazy<TokenApi> token;
        private Lazy<TypeaheadApi> typeahead;
        private Lazy<SuggestApi> suggest;
        private Lazy<GetApi> get;
        private Lazy<SuggestLimitReachedWebhookApi> suggestLimitReachedWebhook;

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

        public GetApi Get
        {
            get { return get.Value; }
        }

        public SuggestApi Suggest
        {
            get { return suggest.Value; }
        }

        public SuggestLimitReachedWebhookApi SuggestLimitReachedWebhook
        {
            get { return suggestLimitReachedWebhook.Value; }
        }

        public TypeaheadApi TypeaheadApi
        {
            get { return typeahead.Value; }
        }

        public AutocompleteApi Autocomplete
        {
            get { return autocomplete.Value; }
        }

        public ApiKeyApi ApiKeyApi
        {
            get { return apiKeyApi.Value; }
        }

        public TokenApi Token
        {
            get { return token.Value; }
        }

        public PermissionApi Permission
        {
            get { return permission.Value; }
        }

        public InvoiceApi Invoices
        {
            get { return invoices.Value; }
        }

        public DistanceApi Distance
        {
            get { return distance.Value; }
        }


        public InvoiceCCApi InvoiceCC
        {
            get { return invoiceCC.Value; }
        }

        public ExpiredCCApi ExpiredCC
        {
            get { return expiredCC.Value; }
        }

        public EmailAddressApi EmailAddress 
        { 
            get { return emailAddress.Value; }
        }

        public SubscriptionApi Subscription
        { 
            get { return subscription.Value; }
        }

        public ApiKey ApiKey
        {
            get;
        }

        public AdminKey AdminKey
        {
            get;
        }

        public AccessToken accessToken;
        public AccessToken AccessToken
        {
            get { return accessToken; }
            set 
            {
                if (!string.IsNullOrWhiteSpace(value?.Value))
                {
                    SetBearerToken(value.Value);
                }
                accessToken = value;
            }
        }


        public SecondLimitReachedWebhookApi SecondLimitReachedWebhook
        {
            get { return  secondLimitReachedWebhook.Value; }
        }

        public PaymentFailedWebhookApi PaymentFailedWebhook
        {
            get { return paymentFailedWebhook.Value; }
        }

        public ExpiredWebhookApi ExpiredWebhook
        {
            get { return expiredWebhook.Value; }
        }

        public TrackWebhookApi TrackWebhook
        {
            get { return trackWebhook.Value; }
        }

        public FirstLimitReachedWebhookApi FirstLimitReachedWebhook
        {
            get { return firstLimitReachedWebhook.Value; }
        }

        public BillingAddressApi BillingAddress
        {
            get { return billingAddress.Value; }
        }

        public PrivateAddressApi PrivateAddress
        {
            get { return privateAddress.Value; }
        }

        public DomainWhitelistApi DomainWhitelist
        {
            get { return domainWhitelist.Value; }
        }

        public IpAddressWhitelistApi IpAddressWhitelist
        {
            get { return ipAddressWhitelist.Value; }
        }

        public UsageApi Usage
        {
            get { return usage.Value; }
        }

        public AddressApi Address
        {
            get { return address.Value; }
        }

        internal void SetAuthorizationKey(Key key = null)
        {
            if (!string.IsNullOrWhiteSpace(key?.Value))
            {
                SetAuthorizationKey(_client, key);
            }
        }
        internal void SetBearerToken(string token)
        {
            SetBearerToken(_client, token);
        }

        internal static void SetBearerToken(HttpClient client, string token)
        {
            client.SetBearerToken(token);
        }

        internal static void SetAuthorizationKey(HttpClient client, Key key)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("api-key", key.Value); 
        }

        internal  async Task<HttpResponseMessage> Post(string path)
        {
            return await Post(_client, path, entity:null);
        }
        internal async Task<HttpResponseMessage> Post(string path, object entity, CancellationToken cancellationToken = default)
        {
            return await Post(_client, path, entity, cancellationToken: cancellationToken);
        }
        internal static async Task<HttpResponseMessage> Post(HttpClient client, string path, object entity, 
            CancellationToken cancellationToken = default)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (path == null) throw new ArgumentNullException(nameof(path));

            HttpContent httpContent = GetHttpContent(client, entity);

            return await client.PostAsync(path, httpContent, cancellationToken:cancellationToken);
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

        internal  async Task<HttpResponseMessage> Delete(string path, int loop = 0)
        {
            return await Delete(_client, path);
        }

        private static async Task<HttpResponseMessage> Delete(HttpClient client, string path)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (path == null) throw new ArgumentNullException(nameof(path));

            return await client.DeleteAsync(path);
        }

        internal async Task<HttpResponseMessage> HttpGet(string path, CancellationToken cancellationToken = default)
        {
            return await HttpGet(_client, path, cancellationToken:cancellationToken); 
        }

        private static async Task<HttpResponseMessage> HttpGet(HttpClient client, string path, CancellationToken cancellationToken = default)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (path == null) throw new ArgumentNullException(nameof(path));

            return await client.GetAsync(path, cancellationToken: cancellationToken);
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
            
        }
    }
}
