using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IPermissionService
    {
        Task<PermissionResponse> Get(GetPermissionRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<AddPermissionResponse> Add(AddPermissionRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<RemovePermissionResponse> Remove(RemovePermissionRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<UpdatePermissionResponse> Update(UpdatePermissionRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
    }

    public class PermissionService : IPermissionService
    {

        public AdminKey AdminKey { get; }
        public HttpClient HttpClient { get; }

        public PermissionService(AdminKey adminKey, HttpClient httpClient = null)
        {
            AdminKey = adminKey ?? throw new System.ArgumentNullException(nameof(adminKey));
            HttpClient = httpClient;
        }

        public async Task<PermissionResponse> Get(GetPermissionRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey, httpClient))
            {
                return await api.Permission.Get(request);
            }
        }

        public async Task<ListPermissionResponse> List(AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey, httpClient))
            {
                return await api.Permission.List();
            }
        }

        public async Task<AddPermissionResponse> Add(AddPermissionRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey, httpClient))
            {
                return await api.Permission.Add(request);
            }
        }

        public async Task<RemovePermissionResponse> Remove(RemovePermissionRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey, httpClient))
            {
                return await api.Permission.Remove(request);
            }
        }

        public async Task<UpdatePermissionResponse> Update(UpdatePermissionRequest request, AdminKey adminKey = null, HttpClient httpClient = null)
        {
            using (var api = new GetAddesssApi(adminKey ?? AdminKey, httpClient))
            {
                return await api.Permission.Update(request);
            }
        }

    }
}