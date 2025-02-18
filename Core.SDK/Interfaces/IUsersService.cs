using Core.Api.Models.Requests.Common;
using Core.Api.Models.Requests.Users;
using Core.Api.Models.Responses.Users;

namespace Core.SDK.Interfaces
{
    public interface IUsersService
    {
        Task<SdkResponse<UserResponse>> GetUser(Guid userGuid);
        Task<SdkResponse<UserResponse>> GetUser(UserSearchRequest userSearchRequest);
        Task<SdkResponse<List<UserApplicationRoleResponse>>> GetUserApplicationRoles(Guid userGuid, Guid applicationGuid);
        Task<SdkResponse<UserRoleResponse>> GetUserRoleByDisplayName(string displayName);
        Task<SdkResponse<UserRoleResponse>> GetUserRoleByUserRoleId(int userRoleId);
        Task<SdkResponse<List<UserRoleResponse>>> GetAllUserRoles();
        Task<SdkResponse<List<UserRoleResponse>>> GetUserRolesByApplicationId(Guid applicationGuid);
        Task<SdkResponse<UserResponse>> AddUser(NewUserRequest newUserRequest);
        Task<SdkResponse<UserResponse>> UpdateUser(Guid userGuid, UpdateUserRequest updateUserRequest);
        Task<SdkResponse<UserAttributeResponse>> UpdateUserInfo(Guid userGuid, AttributeRequest attributeRequest);
        Task<SdkResponse<bool>> DeactivateUser(Guid userGuid);
        Task<SdkResponse<bool>> UpdatePassword(Guid userGuid, UpdateUserPasswordRequest password);
        Task<SdkResponse<UserApplicationRoleResponse>> AddUserApplicationRole(Guid userGuid, AddUserApplicationRoleRequest addUserApplicationRoleRequest);
        Task<SdkResponse<bool>> DeleteUserApplicationRole(int userApplicationRoleId);
    }
}
