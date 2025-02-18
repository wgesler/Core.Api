using Core.Api.Models.Requests.Common;
using Core.Api.Models.Requests.Companies;
using Core.Api.Models.Responses.Companies;
using Core.Domain.Models.Common;
using Core.Domain.Models.Companies;
using FourT.Shared.Utilities.MicroServices.Exceptions;

namespace Core.Api.Helpers.Companies
{
    public class CompanyHelper
    {
        public static Company ConvertNewCompanyRequestToCompany(NewCompanyRequest newCompanyRequest, int createdBy)
        {
            return new Company(newCompanyRequest.DisplayName,
                newCompanyRequest.Info.Select(ConvertNewCompanyAttributeRequestToCompanyAttribute),
                new Audit(createdBy));
        }

        public static Company ConvertUpdateCompanyRequestToCompany(Guid companyGuid, UpdateCompanyRequest updateCompanyRequest, int modifiedBy)
        {
            return new Company(new Identifier(guid:companyGuid), updateCompanyRequest.DisplayName, new Audit(modifiedBy));
        }

        public static CompanyResponse ConvertCompanyToCompanyResponse(Company? company)
        {
            if (company == null)
            {
                throw new AppException("Invalid Company");
            }

            return new CompanyResponse()
            {
                Guid = company.Identifier.Guid, DisplayName = company.DisplayName, IsActive = company.IsActive,
                CreatedOn = company.Audit.CreatedOn,
                CompanyInfo = company.CompanyInfo.Select(ConvertCompanyAttributeToCompanyAttributeResponse),
                CompanyApplications = company.CompanyApplications.Select(ConvertCompanyApplicationToCompanyApplicationResponse)
            };
        }

        public static CompanyAttribute ConvertNewCompanyAttributeRequestToCompanyAttribute(
            AttributeRequest newCompanyAttributeRequest)
        {
            return new CompanyAttribute(newCompanyAttributeRequest.AttributeName,
                newCompanyAttributeRequest.AttributeValue, new Audit(0));
        }

        public static CompanyAttribute ConvertAttributeRequestToCompanyAttribute(
            AttributeRequest updateCompanyAttributeRequest, int companyId, int modifiedBy)
        {
            return new CompanyAttribute(companyId, updateCompanyAttributeRequest.AttributeName,
                updateCompanyAttributeRequest.AttributeValue, new Audit(modifiedBy));
        }

        public static CompanyAttributeResponse ConvertCompanyAttributeToCompanyAttributeResponse(CompanyAttribute? companyAttribute)
        {
            if (companyAttribute == null)
            {
                throw new AppException("Invalid Company Attribute");
            }

            return new CompanyAttributeResponse()
            {
                CompanyInfoId = companyAttribute.CompanyInfoId,
                Value = companyAttribute.Value,
                AttributeId = companyAttribute.AttributeId,
                AttributeName = companyAttribute.AttributeName
            };
        }

        public static CompanyApplicationResponse ConvertCompanyApplicationToCompanyApplicationResponse(CompanyApplication? companyApplication)
        {
            if (companyApplication == null)
            {
                throw new AppException("Invalid Company Application");
            }

            return new CompanyApplicationResponse()
            {
                CompanyApplicationId = companyApplication.CompanyApplicationId,
                CompanyGuid = companyApplication.CompanyIdentifier.Guid,
                ApplicationGuid = companyApplication.ApplicationIdentifier.Guid,
                CreatedBy = companyApplication.Audit.CreatedBy, CreatedOn = companyApplication.Audit.CreatedOn
            };
        }
    }
}
