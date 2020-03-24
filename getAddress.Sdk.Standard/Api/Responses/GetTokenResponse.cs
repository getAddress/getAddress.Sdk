

using System;

namespace getAddress.Sdk.Api.Responses
{
    public  class AccessToken
    {
        public string Value { get; set; }

        public DateTime Expires { get; set; }
    }
    public class RefreshToken
    {
        public string Value { get; set; }

        public DateTime Expires { get; set; }

        public string Url { get; set; }
    }


    public abstract class GetTokenResponse : ResponseBase<GetTokenResponse.Success, GetTokenResponse.Failed>
    {
        protected GetTokenResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {

        }

        public class Success : GetTokenResponse
        {
            
            public Success(int statusCode, string reasonPhrase, string raw, AccessToken accessToken,RefreshToken refreshToken) : base(statusCode, reasonPhrase, raw,true)
            {
                SuccessfulResult = this;
                Access = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
                RefreshToken = refreshToken ?? throw new ArgumentNullException(nameof(refreshToken));
            }

            public AccessToken Access { get; }
            public RefreshToken RefreshToken { get; }
        }

        public class Failed : GetTokenResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                FailedResult = this;
            }
        }
    }
}
