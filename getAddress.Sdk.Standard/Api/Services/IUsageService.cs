﻿using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IUsageService
    {
        Task<GetUsageV3Response> GetV3(AdminKey adminKey = null, HttpClient httpClient = null);
        Task<GetUsageResponse> Get(AdminKey adminKey = null, HttpClient httpClient = null);
        Task<GetUsageResponse> Get(GetUsageRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<GetUsageV3Response> GetV3(GetUsageRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<GetUsageV3Response> GetV3(AccessToken accessToken, HttpClient httpClient = null);
        Task<ListUsageResponse> List(ListUsageRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
        Task<ListUsageResponse> List(AccessToken accessToken, ListUsageRequest request, HttpClient httpClient = null);
        Task<ListUsageResponseV3> ListV3(AccessToken accessToken, ListUsageRequest request, HttpClient httpClient = null);
        Task<ListUsageResponseV3> ListV3(ListUsageRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
       
    }

}