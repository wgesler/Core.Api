using Core.Api.Helpers.Companies;
using Core.Api.Models.Responses.Companies;
using FourT.Shared.Utilities.MicroServices.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.Companies
{
    public partial class CompaniesController
    {
        [AcceptVerbs(new[] { "GET" })]
        [Route("{id:guid}")]
        public async Task<CompanyResponse> GetCompanyByGuid(Guid id)
        {
            return CompanyHelper.ConvertCompanyToCompanyResponse(await Data.CompaniesRepository.GetCompanyByGuid(id));
        }

        [AcceptVerbs(new[] { "GET" })]
        [Route("attribute/{attributeName}")]
        public async Task<List<CompanyResponse>> GetCompaniesByAttribute(string attributeName)
        {
            var companies = new List<CompanyResponse>();
            var coms = await Data.CompaniesRepository.GetCompaniesWhereAttributeExists(attributeName);
            if(coms == null) { throw new AppException("No results"); }
            foreach (var c in coms)
            {
                companies.Add(CompanyHelper.ConvertCompanyToCompanyResponse(c));
            }
            return companies;
        }

        [AcceptVerbs(new[] { "GET" })]
        [Route("application-list/{id:guid}")]
        public async Task<List<string?>> GetApplicationsByCompanyGuid(Guid id)
        {
            return await Data.CompaniesRepository.GetCompanyApplicationListByCompanyGuid(id);
        }
    }
}
