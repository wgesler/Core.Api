using Core.Domain.Interfaces.Repositories;
using Core.Domain.Models.Applications;
using Core.Domain.Models.Common;
using Core.Infrastructure.Repositories.CoreDB.Dtos;

namespace Core.Infrastructure.Repositories.CoreDB.Applications
{
    public partial class ApplicationsRepository : SQLRepository, IApplicationsRepository
    {
        public ApplicationsRepository(string con) : base(con) { }       

        private static Application? ConvertDtoToModel(ApplicationDto? applicationDto)
        {
            if (applicationDto == null) { return null; }

            return new Application(new Identifier(applicationDto.ApplicationId, applicationDto.Guid),
                applicationDto.DisplayName, new Audit(applicationDto.CreatedBy, applicationDto.CreatedOn));
        }
    }
}
