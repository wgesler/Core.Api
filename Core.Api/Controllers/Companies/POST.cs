using Core.Api.Helpers.Companies;
using Core.Api.Models.Requests.Companies;
using Core.Api.Models.Responses.Companies;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.Companies
{
    public partial class CompaniesController
    {
        [AcceptVerbs(new[] { "POST" })]
        [Route("")]
        public async Task<CompanyResponse> AddCompany([FromBody] NewCompanyRequest req)
        {
            if (!req.IsValid())
            {
                throw new Exception("Missing Required Information");
            }

            var application = await Data.ApplicationsRepository.GetApplicationByGuid(req.ApplicationGuid);

            if (application == null || application.Identifier.Id <= 0)
            {
                throw new Exception("Error: Invalid Application");
            }

            try
            {
                var com = await Data.CompaniesRepository.AddCompany(req.DisplayName, 1);

                if (com == null || com.Identifier.Id <= 0)
                {
                    throw new Exception("Failed to create company");
                }

                await Data.CompaniesRepository.AddCompanyApplication(com.Identifier.Id, application.Identifier.Id, 1);

                if (req.Info != null)
                {
                    foreach (var nca in req.Info)
                    {
                        await Data.CompaniesRepository.AddCompanyAttribute(com.Identifier.Id,
                            nca.AttributeName, nca.AttributeValue, 1);
                    }
                }

                return CompanyHelper.ConvertCompanyToCompanyResponse(await Data.CompaniesRepository.GetCompanyById(com.Identifier.Id));
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        [AcceptVerbs(new[] { "POST" })]
        [Route("{companyGuid:guid}/application/{applicationGuid:guid}")]
        public async Task<CompanyApplicationResponse> AddCompanyApplication(Guid companyGuid, Guid applicationGuid)
        {
            var company = await Data.CompaniesRepository.GetCompanyByGuid(companyGuid);
            if (company == null || company.Identifier.Id <= 0)
            {
                throw new Exception("Error: Invalid Company");
            }

            var application = await Data.ApplicationsRepository.GetApplicationByGuid(applicationGuid);
            if (application == null || application.Identifier.Id <= 0)
            {
                throw new Exception("Error: Invalid Application");
            }

            return CompanyHelper.ConvertCompanyApplicationToCompanyApplicationResponse(
                await Data.CompaniesRepository.AddCompanyApplication(company.Identifier.Id, application.Identifier.Id, 1));
        }
    }
}
