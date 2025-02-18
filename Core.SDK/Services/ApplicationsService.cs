using Core.Api.Models.Responses.Applications;
using Core.SDK.Interfaces;
using FourT.Shared.Utilities.MicroServices.Abstracts;
using RestSharp;

namespace Core.SDK.Services
{
    public class ApplicationsService : BaseService,IApplicationsService
    {
        public ApplicationsService(string baseUrl) : base(baseUrl) { }

        public async Task<SdkResponse<ApplicationResponse>> GetApplicationByDisplayName(string displayName)
        {
            return await ExecuteRequest<SdkResponse<ApplicationResponse>, ApplicationResponse>($"/applications/{displayName}",
                Method.Get);
        }

        public async Task<SdkResponse<ApplicationResponse>> GetApplicationIsValidInternalApi(Guid applicationGuid, Guid interalApi)
        {
            var headers = new Dictionary<string, string>();
            headers.Add("apiKey", interalApi.ToString());

            return await ExecuteRequest<SdkResponse<ApplicationResponse>, ApplicationResponse>($"/applications/{applicationGuid}/internal-api-key",
                Method.Get, headers);
        }
    }
}
