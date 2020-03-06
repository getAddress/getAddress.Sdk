

using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class ListPrivateAddressResponse:  ResponseBase<ListPrivateAddressResponse.Success,ListPrivateAddressResponse.Failed>
    {

        protected ListPrivateAddressResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess):base(statusCode,reasonPhrase,raw,isSuccess)
        {
        }

        public class Success : ListPrivateAddressResponse
        {
            public IEnumerable<PrivateAddress> PrivateAddresses { get; }
            internal Success(int statusCode, string reasonPhrase, string raw, IEnumerable<PrivateAddress> privateAddresses) : base(statusCode, reasonPhrase, raw, true)
            {
                PrivateAddresses = privateAddresses;
                SuccessfulResult = this;
            }
        }

        public class Failed : ListPrivateAddressResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                   FailedResult = this;
            }
        }
    }
}
