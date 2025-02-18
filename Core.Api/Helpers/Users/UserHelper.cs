using Core.Api.Models.Requests.Common;
using Core.Api.Models.Requests.Users;
using Core.Api.Models.Responses.Users;
using Core.Domain.Models.Common;
using Core.Domain.Models.Users;
using FourT.Shared.Utilities.Encryption;
using FourT.Shared.Utilities.MicroServices.Exceptions;

namespace Core.Api.Helpers.Users
{
    public class UserHelper
    {
        public static User ConvertNewUserRequestToUser(NewUserRequest newUserRequest, int companyId, int modifiedBy)
        {
            var salt = Pwdtk.GetRandomSalt(Pwdtk.CDefaultSaltLength + 2);
            var hash = Pwdtk.PasswordToHash(salt, newUserRequest.Password, 12345);

            return new User(newUserRequest.EmailAddress, hash, salt, new Identifier(companyId), new Audit(modifiedBy));
        }

        public static User ConvertUpdatePasswordRequestToUser(int userId, string password, int modifiedBy)
        {
            var salt = Pwdtk.GetRandomSalt(Pwdtk.CDefaultSaltLength + 2);
            var hash = Pwdtk.PasswordToHash(salt, password, 12345);

            return new User(new Identifier(userId), hash, salt, new Audit(modifiedBy));
        }

        public static UserResponse ConvertUserToUserResponse(User? user)
        {
            if (user == null)
            {
                throw new AppException("Invalid User");
            }

            return new UserResponse
            {
                Guid = user.Identifier.Guid, EmailAddress = user.EmailAddress, IsActive = user.IsActive, 
				IsLocked = user.IsLocked, FailedLoginAttempts = user.FailedLoginAttempts,
                CompanyId = user.CompanyIdentifier.Guid, CreatedBy = user.Audit.CreatedBy,
                CreatedOn = user.Audit.CreatedOn, ModifiedBy = user.Audit.ModifiedBy,
                ModifiedOn = user.Audit.ModifiedOn,
                UserInfo = user.UserInfo.Select(ConvertUserAttributeToUserAttributeResponse)
            };
        }

        public static UserAttribute ConvertAttributeRequestToUserAttribute(AttributeRequest attributeRequest,
            int userId, int modifiedBy)
        {
            return new UserAttribute(userId, attributeRequest.AttributeName, attributeRequest.AttributeValue,
                new Audit(modifiedBy));
        }

        public static UserAttributeResponse ConvertUserAttributeToUserAttributeResponse(UserAttribute? userAttribute)
        {
            if (userAttribute == null)
            {
                throw new AppException("Invalid User Attribute");
            }

            return new UserAttributeResponse()
            {
                UserInfoId = userAttribute.UserInfoId, Value = userAttribute.Value,
                AttributeId = userAttribute.AttributeId, AttributeName = userAttribute.AttributeName
            };
        }

        public static IEnumerable<UserApplicationRoleResponse> ConvertUserApplicationRolesToUserApplicationRolesResponse(
            IEnumerable<UserApplicationRole> userApplicationRoles)
        {
            return userApplicationRoles.Select(ConvertUserApplicationRoleToUserApplicationRoleResponse);
        }

        public static UserApplicationRoleResponse ConvertUserApplicationRoleToUserApplicationRoleResponse(UserApplicationRole userApplicationRole)
        {
            if (userApplicationRole == null)
            {
                throw new AppException("Invalid User Application Role");
            }

            return new UserApplicationRoleResponse()
            {
                UserApplicationRoleId = userApplicationRole.UserApplicationRoleId,
                UserGuid = userApplicationRole.UserIdentifier.Guid,
                ApplicationGuid = userApplicationRole.ApplicationIdentifier.Guid,
                UserRoleId = userApplicationRole.UserRoleId,
                UserRoleDisplayName = userApplicationRole.UserRoleDisplayName,
                CreatedBy = userApplicationRole.Audit.CreatedBy, CreatedOn = userApplicationRole.Audit.CreatedOn
            };
        }

        public static IEnumerable<UserRoleResponse> ConvertUserRolesToUserRolesResponse(
            IEnumerable<UserRole> userRoles)
        {
            return userRoles.Select(ConvertUserRoleToUserRoleResponse);
        }

        public static UserRoleResponse ConvertUserRoleToUserRoleResponse(UserRole userRole)
        {
            if (userRole == null)
            {
                throw new AppException("Invalid User Role");
            }

            return new UserRoleResponse()
            {
                UserRoleId = userRole.Id,
                DisplayName = userRole.DisplayName,
                CreatedBy = userRole.Audit.CreatedBy,
                CreatedOn = userRole.Audit.CreatedOn,
                ModifiedBy = userRole.Audit.ModifiedBy,
                ModifiedOn = userRole.Audit.ModifiedOn
            };
        }
    }
}
