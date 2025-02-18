using Core.Domain.Interfaces.Repositories;
using Core.Domain.Models.Common;
using Core.Domain.Models.Companies;
using Core.Infrastructure.Repositories.CoreDB.Dtos;

namespace Core.Infrastructure.Repositories.CoreDB.Companies
{
    public partial class CompaniesRepository : SQLRepository, ICompaniesRepository
    {
        public CompaniesRepository(string con) : base(con) { }

        private static Company? ConvertDtoToModel(CompanyDto? companyDto)
        {
            if (companyDto == null) { return null; }

            return new Company(new Identifier(companyDto.CompanyId, companyDto.Guid), companyDto.DisplayName, companyDto.IsActive,
                new Audit(companyDto.CreatedBy, companyDto.CreatedOn, companyDto.ModifiedBy, companyDto.ModifiedOn));
        }

        private static IEnumerable<CompanyAttribute> ConvertDtoToModel(IEnumerable<CompanyAttributeDto> companyAttributeDtos)
        {
            var companyAttributes = new List<CompanyAttribute>();

            foreach (var companyAttributeDto in companyAttributeDtos)
            {
                try
                {
                    companyAttributes.Add(ConvertDtoToModel(companyAttributeDto));
                }
                catch
                {
                    //Maybe log exception here.  I used a try catch so it wouldn't blow up the whole call if one object is invalid
                }
            }

            return companyAttributes;
        }

        private static CompanyAttribute ConvertDtoToModel(CompanyAttributeDto companyAttributeDto)
        {
            return new CompanyAttribute(companyAttributeDto.CompanyInfoId, companyAttributeDto.CompanyId,
                companyAttributeDto.AttributeId, companyAttributeDto.DisplayName, companyAttributeDto.Value,
                new Audit(companyAttributeDto.CreatedBy, companyAttributeDto.CreatedOn, companyAttributeDto.ModifiedBy,
                    companyAttributeDto.ModifiedOn));
        }

        private static IEnumerable<CompanyApplication> ConvertDtoToModel(IEnumerable<CompanyApplicationDto> companyApplicationDtos)
        {
            var companyApplications = new List<CompanyApplication>();

            foreach (var companyApplicationDto in companyApplicationDtos)
            {
                try
                {
                    companyApplications.Add(ConvertDtoToModel(companyApplicationDto));
                }
                catch
                {
                    //Maybe log exception here.  I used a try catch so it wouldn't blow up the whole call if one object is invalid
                }
            }

            return companyApplications;
        }

        private static CompanyApplication ConvertDtoToModel(CompanyApplicationDto companyApplicationDto)
        {
            return new CompanyApplication(companyApplicationDto.CompanyApplicationId, new Identifier(companyApplicationDto.CompanyId, companyApplicationDto.CompanyGuid),
                new Identifier(companyApplicationDto.ApplicationId,
                    companyApplicationDto.ApplicationGuid),
                new Audit(companyApplicationDto.CreatedBy, companyApplicationDto.CreatedOn));
        }
    }
}
