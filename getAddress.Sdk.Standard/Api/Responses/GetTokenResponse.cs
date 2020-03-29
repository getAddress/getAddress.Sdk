using System;

namespace getAddress.Sdk.Api.Responses
{

    public abstract class GetTokenResponse : ResponseBase<GetTokenResponse.Success, GetTokenResponse.Failed, GetTokenResponse.TokenExpired>
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
        }

        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                TokenExpiredResult = this;
                IsTokenExpired = true;
            }
        }
    }
}
