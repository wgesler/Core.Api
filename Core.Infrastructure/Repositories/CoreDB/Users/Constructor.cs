using Core.Domain.Interfaces.Repositories;
using Core.Domain.Models.Common;
using Core.Domain.Models.Users;
using Core.Infrastructure.Repositories.CoreDB.Dtos;
using FourT.Shared.Utilities.MicroServices.Models;

namespace Core.Infrastructure.Repositories.CoreDB.Users
{
    public partial class UsersRepository : SQLRepository, IUsersRepository
    {
        public UsersRepository(string con) : base(con) { }

        private static User? ConvertDtoToModel(UserDto? userDto)
        {
            if (userDto == null)
            {
                return null;
            }

            return new User(new Identifier(userDto.UserId, userDto.Guid), userDto.EmailAddress, userDto.Hash,
                userDto.Salt, userDto.IsActive, userDto.IsLocked, userDto.FailedLoginAttempts, new Identifier(userDto.CompanyId, userDto.CompanyGuid),
                new Audit(userDto.CreatedBy, userDto.CreatedOn, userDto.ModifiedBy, userDto.ModifiedOn));
        }

        private static IEnumerable<UserAttribute> ConvertDtoToModel(IEnumerable<UserAttributeDto> userAttributeDtos)
        {
            var userAttributes = new List<UserAttribute>();

            foreach (var userAttributeDto in userAttributeDtos)
            {
                try
                {
                    userAttributes.Add(ConvertDtoToModel(userAttributeDto));
                }
                catch
                {
                    //Maybe log exception here.  I used a try catch so it wouldn't blow up the whole call if one object is invalid
                }
            }

            return userAttributes;
        }

        private static UserAttribute ConvertDtoToModel(UserAttributeDto userAttributeDto)
        {
            return new UserAttribute(userAttributeDto.UserInfoId, userAttributeDto.UserId,
                userAttributeDto.AttributeId, userAttributeDto.DisplayName, userAttributeDto.Value,
                new Audit(userAttributeDto.CreatedBy, userAttributeDto.CreatedOn, userAttributeDto.ModifiedBy,
                    userAttributeDto.ModifiedOn));
        }

        private static IEnumerable<UserRole> ConvertDtoToModel(IEnumerable<UserRoleDto> userRoleDtos)
        {
            var userRoles = new List<UserRole>();

            foreach (var userRoleDto in userRoleDtos)
            {
                try
                {
                    userRoles.Add(ConvertDtoToModel(userRoleDto));
                }
                catch
                {
                    //Maybe log exception here.  I used a try catch so it wouldn't blow up the whole call if one object is invalid
                }
            }

            return userRoles;
        }

        private static UserRole ConvertDtoToModel(UserRoleDto userRoleDto)
        {
            return new UserRole(userRoleDto.UserRoleId, userRoleDto.DisplayName,
                new Audit(userRoleDto.CreatedBy, userRoleDto.CreatedOn));
        }

        private static IEnumerable<UserApplicationRole> ConvertDtoToModel(IEnumerable<UserApplicationRoleDto> userApplicationRoleDtos)
        {
            var userApplicationRoles = new List<UserApplicationRole>();

            foreach (var userApplicationRoleDto in userApplicationRoleDtos)
            {
                try
                {
                    userApplicationRoles.Add(ConvertDtoToModel(userApplicationRoleDto));
                }
                catch
                {
                    //Maybe log exception here.  I used a try catch so it wouldn't blow up the whole call if one object is invalid
                }
            }

            return userApplicationRoles;
        }

        private static UserApplicationRole ConvertDtoToModel(UserApplicationRoleDto userApplicationRoleDto)
        {
            return new UserApplicationRole(userApplicationRoleDto.UserApplicationRoleId,
                new Identifier(userApplicationRoleDto.UserId, userApplicationRoleDto.UserGuid),
                new Identifier(userApplicationRoleDto.ApplicationId, userApplicationRoleDto.ApplicationGuid),
                userApplicationRoleDto.UserRoleId, userApplicationRoleDto.UserRoleDisplayName,
                new Audit(userApplicationRoleDto.CreatedBy, userApplicationRoleDto.CreatedOn));
        }
    }
}
