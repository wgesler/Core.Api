using Core.Domain.Models.Companies;
using FourT.Shared.Utilities.Extensions;
using System.Data.SqlClient;

namespace Core.Infrastructure.Repositories.CoreDB.Companies
{
    public partial class CompaniesRepository
    {
        public async Task<Company?> UpdateCompany(int companyId, string displayName, int modifiedBy)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<int>("dbo.Companies_Update",
                    new { CompanyId = companyId, DisplayName = displayName, ModifiedBy = modifiedBy });

                return await GetCompanyById(ret.FirstOrDefault());
            }
        }

        public async Task<bool> DeactivateCompany(int id, int modifiedBy)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcExecuteAsync("dbo.Companies_Deactivate",
                    new { CompanyId = id, ModifiedBy = modifiedBy });

                return ret > 0;
            }
        }
    }
}
