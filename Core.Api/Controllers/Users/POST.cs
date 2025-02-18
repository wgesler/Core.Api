using Core.Api.Helpers.Users;
using Core.Api.Models.Requests.Users;
using Core.Api.Models.Responses.Users;
using FourT.Shared.Utilities.MicroServices.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.Users
{
    public partial class UsersController
    {
        [AcceptVerbs(new[] { "POST" })]
        [Route("")]
        public async Task<UserResponse> AddUser([FromBody] NewUserRequest newUserRequest)
        {
            if (!newUserRequest.IsValid())
            {
                throw new AppException(newUserRequest.InvalidMessage());
            }

            var existingUser = await Data.UsersRepository.GetUserByEmailAddress(newUserRequest.EmailAddress);
            if (existingUser != null && existingUser.Identifier.Id > 0)
            {
                throw new AppException("User already exists.");
            }
            
            var company = await Data.CompaniesRepository.GetCompanyByGuid(newUserRequest.CompanyId);
            if (company == null || company.Identifier.Id <= 0)
            {
                throw new AppException("Invalid Company");
            }

            var newUser = UserHelper.ConvertNewUserRequestToUser(newUserRequest, company.Identifier.Id, 1);

            var user = await Data.UsersRepository.AddUser(newUser.EmailAddress, newUser.CompanyIdentifier.Id, newUser.Hash,
                newUser.Salt, 1);

            if (user == null || user.Identifier.Id <= 0)
            {
                throw new AppException("Failed to create user");
            }

            if (newUserRequest.Info != null)
            {
                foreach (var newAttributeRequest in newUserRequest.Info)
                {
                    await Data.UsersRepository.AddUserAttribute(user.Identifier.Id,
                        newAttributeRequest.AttributeName, newAttributeRequest.AttributeValue, 1);
                }
            }

            return UserHelper.ConvertUserToUserResponse(await Data.UsersRepository.GetUserById(user.Identifier.Id));
        }

        [AcceptVerbs(new[] { "POST" })]
        [Route("{userGuid:guid}/roles")]
        public async Task<UserApplicationRoleResponse> AddUserApplicationRole(Guid userGuid, [FromBody] AddUserApplicationRoleRequest addUserApplicationRoleRequest)
        {
            if (!addUserApplicationRoleRequest.IsValid())
            {
                throw new AppException("Invalid Request");
            }

            var user = await Data.UsersRepository.GetUserByGuid(userGuid);
            if (user == null || user.Identifier.Id <= 0)
            {
                throw new AppException("Invalid User");
            }

            var application = await Data.ApplicationsRepository.GetApplicationByGuid(addUserApplicationRoleRequest.ApplicationGuid);
            if (application == null || application.Identifier.Id <= 0)
            {
                throw new AppException("Invalid Company");
            }

            var role = await Data.UsersRepository.GetRoleByUserRoleId(addUserApplicationRoleRequest.UserRoleId);
            if (role == null || role.Id <= 0)
            {
                throw new AppException("Invalid Role");
            }

            return UserHelper.ConvertUserApplicationRoleToUserApplicationRoleResponse(
                await Data.UsersRepository.AddUserApplicationRole(user.Identifier.Id, application.Identifier.Id,
                    role.Id, 0));
        }

        [AcceptVerbs(new[] { "POST" })]
        [Route("search")]
        public async Task<UserResponse> CheckUserByEmailAddress([FromBody] UserSearchRequest usr)
        {
            var response = UserHelper.ConvertUserToUserResponse(await Data.UsersRepository.GetUserByEmailAddress(usr.EmailAddress));
            return response;
        }
    }
}
