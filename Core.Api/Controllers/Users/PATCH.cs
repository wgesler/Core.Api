using Core.Api.Helpers.Users;
using Core.Api.Models.Requests.Common;
using Core.Api.Models.Requests.Users;
using Core.Api.Models.Responses.Users;
using FourT.Shared.Utilities.MicroServices.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.Users
{
    public partial class UsersController
    {
        [AcceptVerbs(new[] { "PATCH" })]
        [Route("{id:guid}")]
        public async Task<UserResponse> UpdateUser(Guid id, [FromBody] UpdateUserRequest req)
        {
            try
            {
                var user = await Data.UsersRepository.GetUserByGuid(id);
                if (user == null || user.Identifier.Id <= 0)
                    throw new AppException("Error: Invalid User");

                var company = await Data.CompaniesRepository.GetCompanyByGuid(req.CompanyId);
                if (company == null || company.Identifier.Id <= 0)
                    throw new AppException("Error: Invalid Company");

				return UserHelper.ConvertUserToUserResponse(await Data.UsersRepository.UpdateUser(user.Identifier.Id, company.Identifier.Id, 0));
			}
			catch (Exception ex)
            {
                throw new AppException("Error: " + ex.Message);
            }
        }

        [AcceptVerbs(new[] { "PATCH" })]
        [Route("{userGuid:guid}/userInfo")]
        public async Task<UserAttributeResponse> UpdateUserAttribute(Guid userGuid, [FromBody] AttributeRequest attributeRequest)
        {
            try
            {
                var updateUser = await Data.UsersRepository.GetUserByGuid(userGuid);

                if (updateUser == null || updateUser.Identifier.Id <= 0)
                {
                    throw new AppException("Error: Invalid User");
                }

                var updateUserAttribute =
                    UserHelper.ConvertAttributeRequestToUserAttribute(attributeRequest,
                        updateUser.Identifier.Id, 1);

                return UserHelper.ConvertUserAttributeToUserAttributeResponse(
                    await Data.UsersRepository.AddUserAttribute(updateUser.Identifier.Id,
                        updateUserAttribute.AttributeName, updateUserAttribute.Value, 1));
            }
            catch (Exception ex)
            {
                throw new AppException("Error: " + ex.Message);
            }
        }

        [AcceptVerbs(new[] { "PATCH" })]
        [Route("{id:guid}/deactivate")]
        public async Task<bool> DeactivateUser(Guid id)
        {
            try
            {
                var user = await Data.UsersRepository.GetUserByGuid(id);

                if (user == null || user.Identifier.Id <= 0)
                {
                    throw new AppException("Error: Invalid User");
                }

                return await Data.UsersRepository.DeactivateUser(user.Identifier.Id, 0);
            }
            catch (Exception ex)
            {
                throw new AppException("Error: " + ex.Message);
            }
        }

        [AcceptVerbs(new[] { "PATCH" })]
        [Route("{userGuid:guid}/password")]
        public async Task<bool> UpdatePassword(Guid userGuid, [FromBody] UpdateUserPasswordRequest password)
        {
            try
            {
                var user = await Data.UsersRepository.GetUserByGuid(userGuid);

                if (user == null || user.Identifier.Id <= 0)
                {
                    throw new AppException("Error: Invalid User");
                }

                var updatedUser = UserHelper.ConvertUpdatePasswordRequestToUser(user.Identifier.Id, password.passsword, 1);

                return await Data.UsersRepository.UpdatePassword(updatedUser.Identifier.Id, updatedUser.Hash,
                    updatedUser.Salt, updatedUser.Audit.CreatedBy);
            }
            catch (Exception ex)
            {
                throw new AppException("Error: " + ex.Message);
            }
        }
    }
}
