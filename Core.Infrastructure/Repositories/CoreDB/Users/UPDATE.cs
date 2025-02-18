using Core.Domain.Models.Users;
using System.Data.SqlClient;

namespace Core.Infrastructure.Repositories.CoreDB.Users
{
    public partial class UsersRepository
    {
		public async Task<User?> UpdateUser(int userId, int companyId, int modifiedBy)
		{
			using (var db = new SqlConnection(_dbConnectionString))
			{
				var ret = await db.DapperProcQueryAsync<int>("dbo.Users_Update", new
				{
					UserId = userId,
					CompanyId = companyId,
					ModifiedBy = modifiedBy
				});

				return await GetUserById(ret.FirstOrDefault());
            }
        }

        public async Task<bool> DeactivateUser(int id, int modifiedBy)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcExecuteAsync("dbo.Users_Deactivate", new { 
					UserId = id, 
					ModifiedBy = modifiedBy 
				});

                return ret > 0;
            }
        }

        public async Task<bool> UpdatePassword(int userId, byte[] hash, byte[] salt, int modifiedBy)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcExecuteAsync("dbo.Users_UpdatePassword", new { 
					UserId = userId, 
					Hash = hash, 
					Salt = salt, 
					ModifiedBy = modifiedBy 
				});

                return ret > 0;
            }
        }
    }
}
