using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace getAddress.Sdk.Api
{
    internal static class HttpClientExtensions
    {
        public static void SetToken(this HttpClient client, string scheme, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, token);
        }

        public static void SetBearerToken(this HttpClient client, string token)
        {
            client.SetToken("Bearer", token);
        }
    }
}
