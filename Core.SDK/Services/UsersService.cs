using Core.Api.Models.Requests.Common;
using Core.Api.Models.Requests.Users;
using Core.Api.Models.Responses.Users;
using Core.SDK.Interfaces;
using FourT.Shared.Utilities.MicroServices.Abstracts;
using RestSharp;

namespace Core.SDK.Services
{
    public class UsersService : BaseService,IUsersService
    {
        public UsersService(string baseUrl) : base(baseUrl) { }

        public async Task<SdkResponse<UserResponse>> GetUser(Guid userGuid)
        {
            return await ExecuteRequest<SdkResponse<UserResponse>, UserResponse>($"/users/{userGuid}", Method.Get);
        }

        public async Task<SdkResponse<UserResponse>> GetUser(UserSearchRequest userSearchRequest)
        {
            return await ExecuteRequest<SdkResponse<UserResponse>, UserResponse>("/users/search", Method.Post, userSearchRequest);
        }

        public async Task<SdkResponse<List<UserApplicationRoleResponse>>> GetUserApplicationRoles(Guid userGuid, Guid applicationGuid)
        {
            return await
                ExecuteRequest<SdkResponse<List<UserApplicationRoleResponse>>, List<UserApplicationRoleResponse>>(
                    $"/users/{userGuid}/roles/{applicationGuid}", Method.Get);
        }

        public async Task<SdkResponse<UserRoleResponse>> GetUserRoleByDisplayName(string displayName)
        {
            return await ExecuteRequest<SdkResponse<UserRoleResponse>, UserRoleResponse>($"/users/roles/{displayName}",
                Method.Get);
        }

        public async Task<SdkResponse<UserRoleResponse>> GetUserRoleByUserRoleId(int userRoleId)
        {
            return await ExecuteRequest<SdkResponse<UserRoleResponse>, UserRoleResponse>($"/users/roles/{userRoleId}",
                Method.Get);
        }

        public async Task<SdkResponse<List<UserRoleResponse>>> GetAllUserRoles()
        {
            return await ExecuteRequest<SdkResponse<List<UserRoleResponse>>, List<UserRoleResponse>>("/users/roles/",
                Method.Get);
        }

        public async Task<SdkResponse<List<UserRoleResponse>>> GetUserRolesByApplicationId(Guid applicationGuid)
        {
            return await ExecuteRequest<SdkResponse<List<UserRoleResponse>>, List<UserRoleResponse>>(
                $"/users/roles/{applicationGuid}", Method.Get);
        }

        public async Task<SdkResponse<UserResponse>> AddUser(NewUserRequest newUserRequest)
        {
            return await ExecuteRequest<SdkResponse<UserResponse>, UserResponse>("/users", Method.Post,
                newUserRequest);
        }

        public async Task<SdkResponse<UserResponse>> UpdateUser(Guid userGuid, UpdateUserRequest updateUserRequest)
        {
            return await ExecuteRequest<SdkResponse<UserResponse>, UserResponse>($"/users/{userGuid}", Method.Patch,
                updateUserRequest);
        }

        public async Task<SdkResponse<UserAttributeResponse>> UpdateUserInfo(Guid userGuid, AttributeRequest attributeRequest)
        {
            return await ExecuteRequest<SdkResponse<UserAttributeResponse>, UserAttributeResponse>(
                $"/users/{userGuid}/userInfo", Method.Patch, attributeRequest);
        }

        public async Task<SdkResponse<bool>> DeactivateUser(Guid userGuid)
        {
            return await ExecuteRequest<SdkResponse<bool>, bool>($"/users/{userGuid}/deactivate", Method.Patch);
        }

        public async Task<SdkResponse<bool>> UpdatePassword(Guid userGuid, UpdateUserPasswordRequest password)
        {
            return await ExecuteRequest<SdkResponse<bool>, bool>($"/users/{userGuid}/password", Method.Patch, password);
        }

        public async Task<SdkResponse<UserApplicationRoleResponse>> AddUserApplicationRole(Guid userGuid, AddUserApplicationRoleRequest addUserApplicationRoleRequest)
        {
            return await ExecuteRequest<SdkResponse<UserApplicationRoleResponse>, UserApplicationRoleResponse>(
                $"/users/{userGuid}/roles", Method.Post, addUserApplicationRoleRequest);
        }

        public async Task<SdkResponse<bool>> DeleteUserApplicationRole(int userApplicationRoleId)
        {
            return await ExecuteRequest<SdkResponse<bool>, bool>($"users/roles/{userApplicationRoleId}", Method.Delete);
        }
    }
}
