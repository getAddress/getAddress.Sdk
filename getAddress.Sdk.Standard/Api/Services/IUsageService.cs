﻿using System.Net.Http;
using System.Threading.Tasks;
using getAddress.Sdk.Api.Requests;
using getAddress.Sdk.Api.Responses;

namespace getAddress.Sdk.Api
{
    public interface IUsageService
    {
        Task<GetUsageResponse> Get(AdminKey adminKey = null, HttpClient httpClient = null);
        Task<GetUsageResponse> Get(GetUsageRequest request, AdminKey adminKey = null, HttpClient httpClient = null);
    }
}