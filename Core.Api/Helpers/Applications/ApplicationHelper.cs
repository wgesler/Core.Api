using Core.Api.Models.Responses.Applications;
using Core.Domain.Models.Applications;

namespace Core.Api.Helpers.Applications
{
    public class ApplicationsHelper
    {
        public static ApplicationResponse ConvertApplicationToApplicationResponse(Application? application)
        {
            if (application == null) return new ApplicationResponse();
            return new ApplicationResponse()
            {
                Guid = application.Identifier.Guid,
                CreatedBy = application.Audit.CreatedBy,
                CreatedOn = application.Audit.CreatedOn,
                DisplayName = application.DisplayName
            };
        }


    }
}
