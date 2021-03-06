﻿using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Responses
{
    public class Usage
    {
        public int Count { get; set; }

        public int Limit1 { get; set; }

        public int Limit2 { get; set; }
    }

    public class UsageV3
    {
        [JsonProperty("usage_today")]
        public int UsageToday { get; set; }

        [JsonProperty("daily_limit")]
        public int DailyLimit { get; set; }

        [JsonProperty("monthly_buffer")]
        public int MonthlyBuffer { get; set; }

        [JsonProperty("monthly_buffer_used")]
        public int MonthlyBufferUsed { get; set; }
    }

    public abstract class GetUsageV3Response : ResponseBase<
        GetUsageV3Response.Success, 
        GetUsageV3Response.Failed, 
        GetUsageV3Response.TokenExpired,
        GetUsageV3Response.RateLimitedReached,
        GetUsageV3Response.Forbidden>
    {

        protected GetUsageV3Response(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : GetUsageV3Response
        {
            public UsageV3 Usage { get; set; }

            public Success(int statusCode, string reasonPhrase, string raw,  UsageV3 usage) : base(statusCode, reasonPhrase, raw, true)
            {
                Usage = usage;
                SuccessfulResult = this;
            }

            public Success(int statusCode, string reasonPhrase, string raw, int dailyLimit, int usageToday, int monthlyBuffer,int monthlyBufferUsed) 
                : this(statusCode, reasonPhrase, raw, new UsageV3
                {
                    DailyLimit = dailyLimit,
                    UsageToday = usageToday,
                    MonthlyBuffer = monthlyBuffer,
                    MonthlyBufferUsed = monthlyBufferUsed
                })
            {}
        }

        public class Failed : GetUsageV3Response
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                FailedResult = this;
            }
        }

        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                TokenExpiredResult = this;
                IsTokenExpired = true;
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
