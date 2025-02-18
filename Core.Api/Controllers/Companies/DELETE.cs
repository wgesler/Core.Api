using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.Companies
{
    public partial class CompaniesController
    {
        [AcceptVerbs(new[] { "DELETE" })]
        [Route("application/{companyApplicationId:int}")]
        public async Task<bool> DeleteCompanyApplication(int companyApplicationId)
        {
            var companyApplication = await Data.CompaniesRepository.GetCompanyApplicationById(companyApplicationId);
            if (companyApplication == null || companyApplication.CompanyApplicationId <= 0)
            {
                throw new Exception("Error: Invalid CompanyApplication");
            }

            return await Data.CompaniesRepository.DeleteCompanyApplication(companyApplication.CompanyApplicationId);
        }
    }
}
