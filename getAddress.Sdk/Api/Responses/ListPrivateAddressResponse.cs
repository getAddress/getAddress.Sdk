

namespace getAddress.Sdk.Api.Responses
{
    public class ListPrivateAddressResponse: AdminResponse
    {

        protected ListPrivateAddressResponse(int statusCode, string reasonPhase, string raw, bool isSuccess):base(statusCode,reasonPhase,raw,isSuccess)
        {
        }

        public class Success : ListPrivateAddressResponse
        {
            public AddressAndId[] Addresses { get; }
            internal Success(int statusCode, string reasonPhase, string raw, AddressAndId[] addresses) : base(statusCode, reasonPhase, raw, true)
            {
                Addresses = addresses;
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
