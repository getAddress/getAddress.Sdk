

using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class ListPrivateAddressResponse: AdminResponse
    {

        protected ListPrivateAddressResponse(int statusCode, string reasonPhase, string raw, bool isSuccess):base(statusCode,reasonPhase,raw,isSuccess)
        {
        }

        public class Success : ListPrivateAddressResponse
        {
            public IEnumerable<PrivateAddress> PrivateAddresses { get; }
            internal Success(int statusCode, string reasonPhase, string raw, IEnumerable<PrivateAddress> privateAddresses) : base(statusCode, reasonPhase, raw, true)
            {
                PrivateAddresses = privateAddresses;
            }
        }

        public class Failed : ListPrivateAddressResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {

            }
        }
    }
}
