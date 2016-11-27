using getAddress.Sdk.Api;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace getAddress.Sdk
{
    public class GetAddesssApi:IDisposable
    {
        private Uri _baseAddress = new Uri("https://api.getaddress.io");

        private readonly HttpClient _client;


        public GetAddesssApi(ApiKey apiKey, AdminKey adminKey, HttpClient httpClient = null)
        {
            _client = httpClient ?? new HttpClient { BaseAddress = _baseAddress };

            _client.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

            AdminKey = adminKey;

            ApiKey = apiKey;

            DomainWhitelist = new DomainWhitelistApi(AdminKey, this);
        }

        public ApiKey ApiKey
        {
            get;
        }

        public AdminKey AdminKey
        {
            get;
        }

        public DomainWhitelistApi DomainWhitelist
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

            entity = entity ?? string.Empty;

            var jsonString = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(entity));
            HttpContent httpContent = new StringContent(jsonString);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return await client.PostAsync(path, httpContent);
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

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
