
using Newtonsoft.Json;

namespace getAddress.Sdk.Api.Requests
{
    public class PermissionRequest
    {
        [JsonProperty("view_invoices")]
        public bool ViewInvoices { get; }

        [JsonProperty("unsubscribe")]
        public bool Unsubscribe { get; }

        public PermissionRequest(bool viewInvoices, bool unsubscribe)//more permissions breaks bw compatibility 
        {
            ViewInvoices = viewInvoices;
            Unsubscribe = unsubscribe;
        }
    }
    public class GetPermissionRequest
    {

        [JsonProperty("email_address")]
        public string EmailAddress
        {
            get;
        }

        public GetPermissionRequest(string emailAddress)
        {
            EmailAddress = emailAddress ?? throw new System.ArgumentNullException(nameof(emailAddress));
        }

    }

    public class RemovePermissionRequest
    {

        [JsonProperty("email_address")]
        public string EmailAddress
        {
            get;
        }

        public RemovePermissionRequest(string emailAddress)
        {
            EmailAddress = emailAddress ?? throw new System.ArgumentNullException(nameof(emailAddress));
        }

    }

    public class UpdatePermissionRequest
    {
        [JsonProperty("email_address")]
        public string EmailAddress { get; }

        public PermissionRequest Permissions { get; }

        public UpdatePermissionRequest(string emailAddress, PermissionRequest permissions)
        {
            EmailAddress = emailAddress ?? throw new System.ArgumentNullException(nameof(emailAddress));
            Permissions = permissions ?? throw new System.ArgumentNullException(nameof(permissions));
        }
    }

    public class AddPermissionRequest
    {
        [JsonProperty("email_address")]
        public string EmailAddress { get; }

        public PermissionRequest Permissions { get; }

        public AddPermissionRequest(string emailAddress, PermissionRequest permissions)
        {
            EmailAddress = emailAddress ?? throw new System.ArgumentNullException(nameof(emailAddress));
            Permissions = permissions ?? throw new System.ArgumentNullException(nameof(permissions));
        }
    }
}
