
using System;

namespace getAddress.Sdk.Api.Responses
{
    public abstract class RefreshTokenResponse : ResponseBase<RefreshTokenResponse.Success, 
        RefreshTokenResponse.Failed, RefreshTokenResponse.TokenExpired>
    {
        protected RefreshTokenResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : RefreshTokenResponse
        {

            public Success(int statusCode, string reasonPhrase, string raw, AccessToken accessToken, RefreshToken refreshToken) : base(statusCode, reasonPhrase, raw, true)
            {
                SuccessfulResult = this;
                Access = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
                RefreshToken = refreshToken ?? throw new ArgumentNullException(nameof(refreshToken));
            }

            public AccessToken Access { get; }
            public RefreshToken RefreshToken { get; }
        }

        public class Failed : RefreshTokenResponse
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
