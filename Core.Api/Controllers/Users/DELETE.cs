using FourT.Shared.Utilities.MicroServices.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.Users
{
    public partial class UsersController
    {
        [AcceptVerbs(new[] { "DELETE" })]
        [Route("roles/{userApplicationRoleId:int}")]
        public async Task<bool> DeleteUserApplicationRole(int userApplicationRoleId)
        {
            var userApplicationRole = await Data.UsersRepository.GetUserApplicationRoleById(userApplicationRoleId);

            if (userApplicationRole == null || userApplicationRole.UserApplicationRoleId <= 0)
            {
                throw new AppException("Error: Invalid UserApplicationRole");
            }

            return await Data.UsersRepository.DeleteUserApplicationRole(userApplicationRole.UserApplicationRoleId);
        }
    }
}
