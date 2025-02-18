
namespace Core.Api.Models.Requests.Users
{
    public class AddUserApplicationRoleRequest
    {
        public Guid ApplicationGuid { get; set; }
        public int UserRoleId { get; set; }

        public bool IsValid()
        {
            return ApplicationGuid != default && UserRoleId > 0;
        }
    }
}
