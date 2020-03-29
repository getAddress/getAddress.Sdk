using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class ListPrivateAddressResponse:  ResponseBase<ListPrivateAddressResponse.Success,
        ListPrivateAddressResponse.Failed, ListPrivateAddressResponse.TokenExpired>
    {

        protected ListPrivateAddressResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess):base(statusCode,reasonPhrase,raw,isSuccess)
        {
        }

        public class Success : ListPrivateAddressResponse
        {
            public IEnumerable<PrivateAddress> PrivateAddresses { get; }
            
            public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<PrivateAddress> privateAddresses) : base(statusCode, reasonPhrase, raw, true)
            {
                PrivateAddresses = privateAddresses;
                SuccessfulResult = this;
            }
        }

        public class Failed : ListPrivateAddressResponse
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
