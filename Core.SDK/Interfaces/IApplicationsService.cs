using FourT.Shared.Utilities.MicroServices.Abstracts;
using Core.Api.Models.Responses.Applications;

namespace Core.SDK.Interfaces
{
    public interface IApplicationsService
    {
        Task<SdkResponse<ApplicationResponse>> GetApplicationByDisplayName(string displayName);
    }
}
