using System.Data.SqlClient;
using FourT.Shared.Utilities.Extensions;

namespace Core.Infrastructure.Repositories.CoreDB.Companies
{
    public partial class CompaniesRepository
    {
        public async Task<bool> DeleteCompanyApplication(int companyApplicationId)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcExecuteAsync("dbo.Companies_DeleteCompanyApplication",
                    new { CompanyApplicationId = companyApplicationId });

                return ret > 0;
            }
        }
    }
}
