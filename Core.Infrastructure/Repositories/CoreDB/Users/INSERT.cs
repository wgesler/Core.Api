using Core.Domain.Models.Users;
using System.Data.SqlClient;


namespace Core.Infrastructure.Repositories.CoreDB.Users
{
    public partial class UsersRepository
    {
        public async Task<User?> AddUser(string emailAddress, int companyId, byte[] hash, byte[] salt, int createdBy)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<int>("dbo.Users_Add",
                    new
                    {
                        EmailAddress = emailAddress, CompanyId = companyId, Hash = hash, Salt = salt,
                        CreatedBy = createdBy
                    });

                return await GetUserById(ret.FirstOrDefault());
            }
        }

        public async Task<UserAttribute?> AddUserAttribute(int userId, string attributeName, string value, int createdBy)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<int>("dbo.Users_AddUserInfoAttribute",
                    new { UserId = userId, AttributeName = attributeName, Value = value, CreatedBy = createdBy });

                return await GetUserAttributeByUserInfoId(ret.FirstOrDefault());
            }
        }

        public async Task<UserApplicationRole?> AddUserApplicationRole(int userId, int applicationId, int userRoleId, int createdBy)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<int>("dbo.Users_AddApplicationPermission",
                    new { UserId = userId, ApplicationId = applicationId, UserRoleId = userRoleId, CreatedBy = createdBy });

                return await GetUserApplicationRoleById(ret.FirstOrDefault());
            }
        }
    }
}
