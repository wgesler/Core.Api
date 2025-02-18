using System.Data.SqlClient;
using FourT.Shared.Utilities.Extensions;

namespace Core.Infrastructure.Repositories.CoreDB.Users
{
    public partial class UsersRepository
    {
        public async Task<bool> DeleteUserApplicationRole(int userApplicationRoleId)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcExecuteAsync("dbo.Users_DeleteUserApplicationRole",
                    new { UserApplicationRoleId = userApplicationRoleId });

                return ret > 0;
            }
        }
    }
}
