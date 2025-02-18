using Core.Domain.Models.Users;

namespace Core.Domain.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task<User?> GetUserByGuid(Guid guid);
        Task<User?> GetUserById(int userId);
        Task<User?> GetUserByEmailAddress(string emailAddress);
        Task<IEnumerable<UserApplicationRole>> GetUserApplicationRolesByUserGuidAndApplicationGuid(Guid userGuid,
            Guid applicationGuid);
        Task<UserApplicationRole?> GetUserApplicationRoleById(int userApplicationRoleId);
        Task<UserRole?> GetRoleByDisplayName(string displayName);
        Task<UserRole?> GetRoleByUserRoleId(int userRoleId);
        Task<IEnumerable<UserRole>?> GetAllUserRoles();
        Task<IEnumerable<UserRole>?> GetUserRolesByApplicationId(Guid applicationId);
        Task<User?> AddUser(string emailAddress, int companyId, byte[] hash, byte[] salt, int createdBy);
        Task<UserApplicationRole?> AddUserApplicationRole(int userId, int applicationId, int userRoleId, int createdBy);
        Task<User?> UpdateUser(int userId, int companyId, int modifiedBy);
        Task<UserAttribute?> AddUserAttribute(int userId, string attributeName, string value, int createdBy);
        Task<bool> DeactivateUser(int id, int modifiedBy);
        Task<bool> UpdatePassword(int userId, byte[] hash, byte[] salt, int modifiedBy);
        Task<bool> DeleteUserApplicationRole(int userApplicationRoleId);
    }
}
