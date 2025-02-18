using Core.Domain.Models.Users;
using Core.Infrastructure.Repositories.CoreDB.Dtos;
using FourT.Shared.Utilities.Extensions;
using System.Data.SqlClient;

namespace Core.Infrastructure.Repositories.CoreDB.Users
{
    public partial class UsersRepository
    {
        public async Task<User?> GetUserByGuid(Guid guid)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<UserDto>("dbo.Users_GetByGUID", new { GUID = guid });

                var user = ConvertDtoToModel(ret.FirstOrDefault());
                user?.SetUserInfo(await GetUserAttributesByUserId(user.Identifier.Id));

                return user;
            }
        }

        public async Task<User?> GetUserById(int userId)
        {

            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<UserDto>("dbo.Users_GetById", new { userId });

                var user = ConvertDtoToModel(ret.FirstOrDefault());
                user?.SetUserInfo(await GetUserAttributesByUserId(user.Identifier.Id));

                return user;
            }
        }

        public async Task<User?> GetUserByEmailAddress(string emailAddress)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<UserDto>("dbo.Users_GetByEmailAddress", new { emailAddress });

                var user = ConvertDtoToModel(ret.FirstOrDefault());
                user?.SetUserInfo(await GetUserAttributesByUserId(user.Identifier.Id));

                return user;
            }
        }

        public async Task<IEnumerable<UserApplicationRole>> GetUserApplicationRolesByUserGuidAndApplicationGuid(Guid userGuid, Guid applicationGuid)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<UserApplicationRoleDto>(
                    "dbo.Users_GetRolesByUserGuidAndApplicationGuid", new { userGuid, applicationGuid });

                return ConvertDtoToModel(ret);
            }
        }

        public async Task<IEnumerable<UserAttribute>> GetUserAttributesByUserId(int id)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<UserAttributeDto>("dbo.Users_GetAttributesByUserId",
                    new { UserId = id });

                return ConvertDtoToModel(ret);
            }
        }

        public async Task<UserAttribute?> GetUserAttributeByUserInfoId(int id)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<UserAttributeDto>("dbo.Users_GetUserAttributeByUserInfoId",
                    new { UserInfoId = id });

                return ConvertDtoToModel(ret.FirstOrDefault());
            }
        }

        public async Task<UserRole?> GetRoleByDisplayName(string displayName)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<UserRoleDto>("dbo.Users_GetUserRoleByDisplayName",
                    new { DisplayName = displayName });

                return ConvertDtoToModel(ret.FirstOrDefault());
            }
        }

        public async Task<UserApplicationRole?> GetUserApplicationRoleById(int userApplicationRoleId)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<UserApplicationRoleDto>("dbo.Users_GetUserApplicationRoleById",
                    new { UserApplicationRoleId = userApplicationRoleId });

                return ConvertDtoToModel(ret.FirstOrDefault());
            }
        }

        public async Task<UserRole?> GetRoleByUserRoleId(int userRoleId)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<UserRoleDto>("dbo.Users_GetUserRoleByUserRoleId",
                    new { UserRoleId = userRoleId });

                return ConvertDtoToModel(ret.FirstOrDefault());
            }
        }

        public async Task<IEnumerable<UserRole>?> GetAllUserRoles()
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<UserRoleDto>("dbo.Users_GetAllUserRoles", new { });

                return ConvertDtoToModel(ret);
            }
        }

        public async Task<IEnumerable<UserRole>?> GetUserRolesByApplicationId(Guid applicationId)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<UserRoleDto>("dbo.Users_GetUserRolesByApplicationGuid",
                    new { ApplicationGuid = applicationId });

                return ConvertDtoToModel(ret);
            }
        }
    }
}
