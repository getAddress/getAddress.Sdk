﻿using System;

namespace getAddress.Sdk.Api.Responses
{

    public abstract class GetTokenResponse : ResponseBase<
        GetTokenResponse.Success, 
        GetTokenResponse.Failed, 
        GetTokenResponse.TokenExpired,
        GetTokenResponse.RateLimitedReached,
        GetTokenResponse.Forbidden>
    {
        protected GetTokenResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : GetTokenResponse
        {
            
            public Success(int statusCode, string reasonPhrase, string raw, AccessToken accessToken,RefreshToken refreshToken) : base(statusCode, reasonPhrase, raw,true)
            {
                SuccessfulResult = this;
                AccessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
                RefreshToken = refreshToken ?? throw new ArgumentNullException(nameof(refreshToken));
            }

            public AccessToken AccessToken { get; }
            public RefreshToken RefreshToken { get; }
        }

        public class Failed : GetTokenResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                FailedResult = this;
            }

            internal static Failed NewFailed(int statusCode, string reasonPhrase, string raw)
            {
                return new Failed(statusCode, reasonPhrase, raw);
            }
        }

        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                TokenExpiredResult = this;
                IsTokenExpired = true;
            }

            internal static TokenExpired NewTokenExpired(string reasonPhrase, string raw)
            {
                return new TokenExpired(reasonPhrase, raw);
            }
        }

        public class RateLimitedReached : Failed
        {
            public double RetryAfterSeconds { get; }
            public RateLimitedReached(string reasonPhrase, string raw, double retryAfterSeconds) : base(429, reasonPhrase, raw)
            {
                RetryAfterSeconds = retryAfterSeconds;
                RateLimitReachedResult = this;
                IsRateLimitReached = true;
            }

            internal static RateLimitedReached NewRateLimitedReached(string reasonPhrase, string raw, double retryAfterSeconds)
            {
                return new RateLimitedReached(reasonPhrase, raw, retryAfterSeconds);
            }
        }

        public class Forbidden : Failed
        {
            public Forbidden(string reasonPhrase, string raw) : base(403, reasonPhrase, raw)
            {
                ForbiddenResult = this;
                IsForbidden = true;
            }
        }

    }
}
