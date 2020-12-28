using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace getAddress.Sdk.Api
{
    public interface IFirstLimitReachedEmailNotificationService
    {
        Task<AddEmailNotificationResponse> Add(AddEmailNotificationRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<AddEmailNotificationResponse> Add(AddEmailNotificationRequest request, AccessToken accessToken, HttpClient httpClient = null);
        Task<GetEmailNotificationResponse> Get(GetEmailNotificationRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<GetEmailNotificationResponse> Get(GetEmailNotificationRequest request, AccessToken accessToken, HttpClient httpClient = null);
        Task<ListEmailNotificationResponse> List(AdminKey adminKey = null, HttpClient httpClient = null);
        Task<ListEmailNotificationResponse> List(AccessToken accessToken, HttpClient httpClient = null);
        Task<RemoveEmailNotificationResponse> Remove(RemoveEmailNotificationRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<RemoveEmailNotificationResponse> Remove(RemoveEmailNotificationRequest request, AccessToken accessToken, HttpClient httpClient = null);
    }
}