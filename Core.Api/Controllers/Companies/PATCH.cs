using Core.Api.Helpers.Companies;
using Core.Api.Models.Requests.Common;
using Core.Api.Models.Requests.Companies;
using Core.Api.Models.Responses.Companies;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.Companies
{
	public partial class CompaniesController
    {
        [AcceptVerbs(new[] { "PATCH" })]
        [Route("{id:guid}")]
        public async Task<CompanyResponse> UpdateCompany(Guid id, [FromBody] UpdateCompanyRequest updateCompanyRequest)
        {
            try
            {
                var updateCompany = CompanyHelper.ConvertUpdateCompanyRequestToCompany(id, updateCompanyRequest, 1);

                var originalCompany = await Data.CompaniesRepository.GetCompanyByGuid(updateCompany.Identifier.Guid);

                if (originalCompany == null || originalCompany.Identifier.Id <= 0)
                {
                    throw new Exception("Error: Invalid Company");
                }

                return CompanyHelper.ConvertCompanyToCompanyResponse(
                    await Data.CompaniesRepository.UpdateCompany(originalCompany.Identifier.Id, updateCompany.DisplayName,
                        updateCompany.Audit.CreatedBy));
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        [AcceptVerbs(new[] { "PATCH" })]
        [Route("{companyId:guid}/companyInfo")]
        public async Task<CompanyAttributeResponse> UpdateCompanyInfo(Guid companyId, [FromBody] AttributeRequest attributeRequest)
        {
            try
            {
                var updateCompany = await Data.CompaniesRepository.GetCompanyByGuid(companyId);

                if (updateCompany == null || updateCompany.Identifier.Id <= 0)
                {
                    throw new Exception("Error: Invalid Company");
                }

                var updateCompanyAttribute =
                    CompanyHelper.ConvertAttributeRequestToCompanyAttribute(attributeRequest,
                        updateCompany.Identifier.Id, 1);

                return CompanyHelper.ConvertCompanyAttributeToCompanyAttributeResponse(
                    await Data.CompaniesRepository.AddCompanyAttribute(updateCompany.Identifier.Id,
                        updateCompanyAttribute.AttributeName, updateCompanyAttribute.Value, 1));
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        [AcceptVerbs(new[] { "PATCH" })]
        [Route("{id:guid}/deactivate")]
        public async Task<bool> DeactivateCompany(Guid id)
        {
            try
            {
                var company = await Data.CompaniesRepository.GetCompanyByGuid(id);

                if (company == null || company.Identifier.Id <= 0)
                {
                    throw new Exception("Error: Invalid Company");
                }

                return await Data.CompaniesRepository.DeactivateCompany(company.Identifier.Id, 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

		[AcceptVerbs(new[] { "PATCH" })]
		[Route("{id:guid}/application-list")]
		public async Task UpdateApplicationsByCompanyGuid(Guid id, UpdateCompanyApplicationsRequest req)
		{
			var company = await Data.CompaniesRepository.GetCompanyByGuid(id);
			if (company == null || company.Identifier.Id <= 0)
				throw new Exception("Error: Invalid Company");

			// Get guids associated with application names
			List<string> applications = new List<string>();
			foreach(var app in req.Applications)
			{
				var application = await Data.ApplicationsRepository.GetApplicationByDisplayName (app);
				if (application != null) applications.Add(application.Identifier.Guid.ToString());
			}

			// Go through each of the current apps and delete those not in req list
			List<string> currentApps = new List<string>();
			var apps = await Data.CompaniesRepository.GetCompanyApplicationsByCompanyId(company.Identifier.Id);
			if (apps != null)
			{
				foreach (var app in apps)
				{
					if (applications.Find(a => a.ToLower() == app.ApplicationIdentifier.Guid.ToString().ToLower()) == null)
						await Data.CompaniesRepository.DeleteCompanyApplication(app.CompanyApplicationId);
					else
						currentApps.Add(app.ApplicationIdentifier.Guid.ToString());
				}

				// Go through each of the requested applications and make sure they're added to the company
				foreach (var app in applications)
				{
					if(currentApps.Find(a => a.ToLower() == app.ToLower()) == null)
					{
						var newApp = await Data.ApplicationsRepository.GetApplicationByGuid(new Guid(app));
						if (newApp == null)
							throw new Exception("Error: Invalid Application");

						await Data.CompaniesRepository.AddCompanyApplication(company.Identifier.Id, newApp.Identifier.Id, 1);
					}
				}
			}
		}
	}
}
