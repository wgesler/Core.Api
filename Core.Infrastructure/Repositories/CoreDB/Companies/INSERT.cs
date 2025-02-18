using Core.Domain.Models.Companies;
using FourT.Shared.Utilities.Extensions;
using System.Data.SqlClient;

namespace Core.Infrastructure.Repositories.CoreDB.Companies
{
    public partial class CompaniesRepository
    {
        public async Task<Company?> AddCompany(string displayName, int createdBy)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<int>("dbo.Companies_Add",
                    new { DisplayName = displayName, CreatedBy = createdBy });

                return await GetCompanyById(ret.FirstOrDefault());
            }
        }

        public async Task<CompanyAttribute?> AddCompanyAttribute(int companyId, string attributeName, string value,
            int createdBy)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<int>("dbo.Companies_AddCompanyInfoAttribute",
                    new { CompanyId = companyId, AttributeName = attributeName, Value = value, CreatedBy = createdBy });

                return await GetCompanyAttributeByCompanyInfoId(ret.FirstOrDefault());
            }
        }

        public async Task<CompanyApplication?> AddCompanyApplication(int companyId, int applicationId, int createdBy)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<int>("dbo.Companies_AddCompanyApplication",
                    new { CompanyId = companyId, ApplicationId = applicationId, CreatedBy = createdBy });

                return await GetCompanyApplicationById(ret.FirstOrDefault());
            }
        }
    }
}
