
namespace Core.Api.Models.Responses.Users
{
    public class UserApplicationRoleResponse
    {
        public int UserApplicationRoleId { get; set; }
        public Guid UserGuid { get; set; }
        public Guid ApplicationGuid { get; set; }
        public int UserRoleId { get; set; }
        public string? UserRoleDisplayName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
