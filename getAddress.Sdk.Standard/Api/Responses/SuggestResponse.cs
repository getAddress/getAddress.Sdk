﻿using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class SuggestResponse: ResponseBase<
        SuggestResponse.Success,
        SuggestResponse.Failed,
        SuggestResponse.TokenExpired,
        SuggestResponse.RateLimitedReached,
        SuggestResponse.Forbidden>
    {

        protected SuggestResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : SuggestResponse
        {
            public IEnumerable<Suggestion> Suggestions { get; }
    
            public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<Suggestion> suggestions) : base(statusCode, reasonPhrase, raw, true)
            {
                Suggestions = suggestions;
                this.SuccessfulResult = this;
            }
        }

        public class Failed : SuggestResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                this.FailedResult = this;
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


        //todo: All Response Types
    }
}
