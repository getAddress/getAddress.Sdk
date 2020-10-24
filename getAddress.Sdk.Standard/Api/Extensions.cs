﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace getAddress.Sdk.Api
{
    internal static class HttpResponseMessageExtensions
    {

        internal static R GetResponse<R>(this HttpResponseMessage response, string body,
            Func<int, string, string, R> success,
            Func<string, string, R> tokenExpired,
            Func<string, string, double, R> rateLimitReached,
            Func<int, string, string, R> failed,
            Func<string, string, R> forbidden,
            Func<string, string, R> notFound = null,
            Func<string, string, R> invalidPostcode = null,
            Func<string, string, R> accountExpired = null,
            Func<string, string, R> limitReached = null,
            Func<string, string, R> confict = null
            )
        {

            if (response.IsSuccessStatusCode)
            {
                return success((int)response.StatusCode, response.ReasonPhrase, body);
            }
            if (response.HasTokenExpired())
            {
                return tokenExpired(response.ReasonPhrase, body);
            }
            if (response.IsRateLimitReached(out double retrySeconds))
            {
                return rateLimitReached(response.ReasonPhrase, body, retrySeconds);
            }
            if (response.IsForbidden())
            {
                return forbidden(response.ReasonPhrase, body);
            }
            if (notFound != null && response.IsNotFound())
            {
                return notFound(response.ReasonPhrase, body);
            }
            if (invalidPostcode != null && response.IsInvalidPostcode())
            {
                return invalidPostcode(response.ReasonPhrase, body);
            }
            if (accountExpired != null && response.HasAccountExpired())
            {
                return accountExpired(response.ReasonPhrase, body);
            }
            if (limitReached != null && response.IsLimitReached())
            {
                return limitReached(response.ReasonPhrase, body);
            }
            if (confict != null && response.IsConflict())
            {
                return confict(response.ReasonPhrase, body);
            }

            return failed((int)response.StatusCode, response.ReasonPhrase, body);
        }


        public static bool HasTokenExpired(this HttpResponseMessage httpResponseMessage)
        {
            return httpResponseMessage.Headers.Contains("Token-Expired") && httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized;
        }

        public static bool HasAccountExpired(this HttpResponseMessage httpResponseMessage)
        {
            return httpResponseMessage.Headers.Contains("Account-Expired") && httpResponseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest;
        }

        public static bool IsNotFound(this HttpResponseMessage httpResponseMessage)
        {
            return httpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound;
        }

        public static bool IsForbidden(this HttpResponseMessage httpResponseMessage)
        {
            return httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Forbidden;
        }

        public static bool IsInvalidPostcode(this HttpResponseMessage httpResponseMessage)
        {
            return httpResponseMessage.Headers.Contains("Invalid-Postcode") && httpResponseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest;
        }

        public static bool IsRateLimitReached(this HttpResponseMessage httpResponseMessage)
        {
            return httpResponseMessage.Headers.Contains("Retry-After") && (int)httpResponseMessage.StatusCode == 429;
        }

       
        public static bool IsLimitReached(this HttpResponseMessage httpResponseMessage)
        {
            return httpResponseMessage.Headers.Contains("Limit-Reached") && (int)httpResponseMessage.StatusCode == 429;
        }

        public static bool IsConflict(this HttpResponseMessage httpResponseMessage)
        {
            return httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Conflict;
        }

        public static bool IsRateLimitReached(this HttpResponseMessage httpResponseMessage, out double retryAfter)
        {
            if (IsRateLimitReached(httpResponseMessage))
            {
                retryAfter = double.Parse(httpResponseMessage.Headers.GetValues("Retry-After").First());
                return true;
            }
                retryAfter = 0;
                return false;
        }

    }

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
