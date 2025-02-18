using Core.Api.Models.Requests.Common;
using Core.Api.Models.Requests.Companies;
using Core.Api.Models.Responses.Companies;

namespace Core.SDK.Interfaces
{
    public interface ICompaniesService
    {
		// Company
        Task<SdkResponse<CompanyResponse>> GetCompany(Guid companyGuid);
        Task<SdkResponse<CompanyResponse>> AddCompany(NewCompanyRequest newCompanyRequest);
        Task<SdkResponse<CompanyResponse>> UpdateCompany(Guid companyGuid, UpdateCompanyRequest updateCompanyRequest);
        Task<SdkResponse<CompanyAttributeResponse>> UpdateCompanyInfo(Guid companyGuid, AttributeRequest attributeRequest);
        Task<SdkResponse<bool>> DeactivateCompany(Guid companyGuid);

		// Company Applications
		Task<SdkResponse<CompanyApplicationResponse>> AddCompanyApplication(Guid companyGuid, Guid applicationGuid);
        Task<SdkResponse<bool>> DeleteCompanyApplication(int companyApplicationId);
		Task<SdkResponse<List<string?>>> GetCompanyApplicationListByCompanyGuid(Guid companyGuid);
		Task<SdkResponse<bool>> UpdateCompanyApplications(Guid companyGuid, UpdateCompanyApplicationsRequest companyApplications);

		// User Company Applications
	}
}
