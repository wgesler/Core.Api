using Core.Api.Models.Requests.Common;
using Core.Api.Models.Requests.Companies;
using Core.Api.Models.Responses.Companies;
using Core.SDK.Interfaces;
using RestSharp;

namespace Core.SDK.Services
{
    public class CompaniesService : BaseService, ICompaniesService
    {
        public CompaniesService(string baseUrl) : base(baseUrl) { }

        public async Task<SdkResponse<CompanyResponse>> GetCompany(Guid companyGuid)
        {
            return await ExecuteRequest<SdkResponse<CompanyResponse>, CompanyResponse>($"/companies/{companyGuid}",
                Method.Get);
        }

        public async Task<SdkResponse<CompanyResponse>> AddCompany(NewCompanyRequest newCompanyRequest)
        {
            return await ExecuteRequest<SdkResponse<CompanyResponse>, CompanyResponse>("/companies", Method.Post,
                newCompanyRequest);
        }

        public async Task<SdkResponse<CompanyResponse>> UpdateCompany(Guid companyGuid, UpdateCompanyRequest updateCompanyRequest)
        {
            return await ExecuteRequest<SdkResponse<CompanyResponse>, CompanyResponse>($"/companies/{companyGuid}",
                Method.Patch, updateCompanyRequest);
        }

        public async Task<SdkResponse<CompanyAttributeResponse>> UpdateCompanyInfo(Guid companyGuid,
            AttributeRequest attributeRequest)
        {
            return await ExecuteRequest<SdkResponse<CompanyAttributeResponse>, CompanyAttributeResponse>(
                $"/companies/{companyGuid}/companyInfo", Method.Patch, attributeRequest);
        }

        public async Task<SdkResponse<bool>> DeactivateCompany(Guid companyGuid)
        {
            return await ExecuteRequest<SdkResponse<bool>, bool>($"/companies/{companyGuid}/deactivate",
                Method.Patch);
        }

        public async Task<SdkResponse<CompanyApplicationResponse>> AddCompanyApplication(Guid companyGuid, Guid applicationGuid)
        {
            return await ExecuteRequest<SdkResponse<CompanyApplicationResponse>, CompanyApplicationResponse>(
                $"/companies/{companyGuid}/application/{applicationGuid}", Method.Post);
        }

        public async Task<SdkResponse<bool>> DeleteCompanyApplication(int companyApplicationId)
        {
            return await ExecuteRequest<SdkResponse<bool>, bool>($"/companies/application/{companyApplicationId}",
                Method.Delete);
        }

		public async Task<SdkResponse<List<string?>>> GetCompanyApplicationListByCompanyGuid(Guid companyGuid)
		{
			return await ExecuteRequest<SdkResponse<List<string?>>, List<string?>>($"/companies/application-list/{companyGuid}",
				Method.Get);
		}

		public async Task<SdkResponse<bool>> UpdateCompanyApplications(Guid companyGuid, UpdateCompanyApplicationsRequest companyApplications)
		{
			return await ExecuteRequest<SdkResponse<bool>, bool>($"/companies/{companyGuid}/application-list", 
				Method.Patch, companyApplications);
		}
	}
}
