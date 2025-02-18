using Core.Api.Helpers.Applications;
using Core.Api.Models.Responses.Applications;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.Applications
{
    public partial class ApplicationsController
    {
        [AcceptVerbs(new[] { "GET" })]
        [Route("{displayName}")]
        public async Task<ApplicationResponse> GetApplicationByName(string displayName)
        {
            var application = await Data.ApplicationsRepository.GetApplicationByDisplayName(displayName);
            return ApplicationsHelper.ConvertApplicationToApplicationResponse(application);
        }

        [AcceptVerbs(new[] { "GET" })]
        [Route("{applicationGuid:guid}/internal-api-key")]
        public async Task<bool> GetApplicationIsValidApi(Guid applicationGuid, [FromHeader] Guid apiKey)
        {
            var valid = await Data.ApplicationsRepository.GetApplicationIsValidApi(applicationGuid, apiKey);
            return valid;
        }

    }
}
