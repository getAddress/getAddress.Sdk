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

        protected GetAddesssApi GetAddesssApi(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            if (AccessToken != null && adminKey == null)
            {
                return new GetAddesssApi(AccessToken, HttpClient ?? httpClient);
            }
            else
            {
                return new GetAddesssApi(adminKey ?? AdminKey, HttpClient ?? httpClient);
            }
        }

        protected GetAddesssApi GetAddesssApi(ApiKey apiKey = null, HttpClient httpClient = null)
        {
            if (AccessToken != null && apiKey == null)
            {
                return new GetAddesssApi(AccessToken, HttpClient ?? httpClient);
            }
            else
            {
                return new GetAddesssApi(apiKey ?? ApiKey, HttpClient ?? httpClient);
            }
        }

        public AdminKey AdminKey { get; protected set;}

        public ApiKey ApiKey { get; protected set; }

        public AccessToken AccessToken { get; }
        public HttpClient HttpClient { get; }
    }
}
