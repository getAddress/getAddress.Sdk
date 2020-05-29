using getAddress.Sdk.Api.Responses;
using System.Collections.Generic;

public class ListUsage
{
    public int Count { get; set; }

    public System.DateTime Date { get; set; }
}

public class ListUsageV3
{
    public int Count { get; set; }

    public System.DateTime Date { get; set; }

    public int Limit { get; set; }
}

public abstract class ListUsageResponse : ResponseBase<
    ListUsageResponse.Success, 
    ListUsageResponse.Failed, 
    ListUsageResponse.TokenExpired,
    ListUsageResponse.RateLimitedReached,
    ListUsageResponse.Forbidden>
{

    protected ListUsageResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
    {

    }

    public class Success : ListUsageResponse
    {
        public IEnumerable<ListUsage> Usages {get;}
        
        public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<ListUsage> usages) : base(statusCode, reasonPhrase, raw, true)
        {
            
            SuccessfulResult = this;
            Usages = usages ?? throw new System.ArgumentNullException(nameof(usages));
        }
    }

    public class Failed : ListUsageResponse
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


public abstract class ListUsageResponseV3 : ResponseBase<
    ListUsageResponseV3.Success,
    ListUsageResponseV3.Failed,
    ListUsageResponseV3.TokenExpired,
    ListUsageResponseV3.RateLimitedReached,
    ListUsageResponseV3.Forbidden>
{

    protected ListUsageResponseV3(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
    {

    }

    public class Success : ListUsageResponseV3
    {
        public IEnumerable<ListUsageV3> Usages { get; }

        public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<ListUsageV3> usages) : base(statusCode, reasonPhrase, raw, true)
        {

            SuccessfulResult = this;
            Usages = usages ?? throw new System.ArgumentNullException(nameof(usages));
        }
    }

    public class Failed : ListUsageResponseV3
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