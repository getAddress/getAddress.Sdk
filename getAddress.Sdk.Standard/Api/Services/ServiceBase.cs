using System.Net.Http;

namespace getAddress.Sdk.Api
{
    public abstract class ServiceBase
    {
        protected ServiceBase(HttpClient httpClient = null)
        {
            HttpClient = httpClient;
        }
        

        protected ServiceBase(AccessToken accessToken, HttpClient httpClient = null) : this(httpClient)
        {
            AccessToken = accessToken ?? throw new System.ArgumentNullException(nameof(accessToken));
        }

        protected GetAddesssApi GetAddesssApi(HttpClient httpClient = null)
        {
              return new GetAddesssApi(httpClient ?? HttpClient);
        }

        protected GetAddesssApi GetAddesssApi(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            if (AccessToken != null && adminKey == null)
            {
                return new GetAddesssApi(AccessToken, httpClient ?? HttpClient);
            }
            else
            {
                return new GetAddesssApi(adminKey ?? AdminKey, httpClient ?? HttpClient);
            }
        }

        protected GetAddesssApi GetAddesssApi(ApiKey apiKey = null, HttpClient httpClient = null)
        {
            if (AccessToken != null && apiKey == null)
            {
                return new GetAddesssApi(AccessToken, httpClient ?? HttpClient);
            }
            else
            {
                return new GetAddesssApi(apiKey ?? ApiKey, httpClient ?? HttpClient);
            }
        }

        public AdminKey AdminKey { get; protected set;}

        public ApiKey ApiKey { get; protected set; }

        public AccessToken AccessToken { get; }
        public HttpClient HttpClient { get; }
    }
}
