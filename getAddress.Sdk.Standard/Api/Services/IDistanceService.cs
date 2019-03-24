using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IDistanceService
    {
        AdminKey AdminKey { get; }

        Task<DistanceResponse> Get(DistanceRequest request, AdminKey adminKey = null);
    }
}