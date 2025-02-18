using Core.Api.Helpers.Users;
using Core.Api.Models.Responses.Users;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.Users
{
    public partial class UsersController
    {
        [AcceptVerbs(new[] { "GET" })]
        [Route("{id:guid}")]
        public async Task<UserResponse> GetUserById(Guid id)
        {
            return UserHelper.ConvertUserToUserResponse(await Data.UsersRepository.GetUserByGuid(id));
        }

        [AcceptVerbs(new[] { "GET" })]
        [Route("{emailAddress}")]
        public async Task<UserResponse> GetUserByEmailAddress(string emailAddress)
        {
            return UserHelper.ConvertUserToUserResponse(await Data.UsersRepository.GetUserByEmailAddress(emailAddress));
        }

        [AcceptVerbs(new[] { "GET" })]
        [Route("{userGuid:guid}/roles/{applicationGuid:guid}")]
        public async Task<IEnumerable<UserApplicationRoleResponse>> GetUserApplicationRolesByUserAndApplication(Guid userGuid, Guid applicationGuid)
        {
            return UserHelper.ConvertUserApplicationRolesToUserApplicationRolesResponse(
                await Data.UsersRepository.GetUserApplicationRolesByUserGuidAndApplicationGuid(userGuid,
                    applicationGuid));
        }

        [AcceptVerbs(new[] { "GET" })]
        [Route("roles")]
        public async Task<IEnumerable<UserRoleResponse>> GetUserRoles()
        {
            return UserHelper.ConvertUserRolesToUserRolesResponse(await Data.UsersRepository.GetAllUserRoles());
        }

        [AcceptVerbs(new[] { "GET" })]
        [Route("roles/{applicationGuid:guid}")]
        public async Task<IEnumerable<UserRoleResponse>> GetUserRolesByApplicationId(Guid applicationGuid)
        {
            return UserHelper.ConvertUserRolesToUserRolesResponse(await Data.UsersRepository.GetUserRolesByApplicationId(applicationGuid));
        }

        [AcceptVerbs(new[] { "GET" })]
        [Route("roles/{userRoleId:int}")]
        public async Task<UserRoleResponse> GetUserRoleById(int userRoleId)
        {
            return UserHelper.ConvertUserRoleToUserRoleResponse(await Data.UsersRepository.GetRoleByUserRoleId(userRoleId));
        }

        [AcceptVerbs(new[] { "GET" })]
        [Route("roles/{displayName}")]
        public async Task<UserRoleResponse> GetUserRoleByDisplayName(string displayName)
        {
            return UserHelper.ConvertUserRoleToUserRoleResponse(await Data.UsersRepository.GetRoleByDisplayName(displayName));
        }
    }
}
