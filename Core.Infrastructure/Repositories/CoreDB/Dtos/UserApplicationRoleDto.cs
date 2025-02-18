
namespace Core.Infrastructure.Repositories.CoreDB.Dtos
{
    public class UserApplicationRoleDto
    {
        public int UserApplicationRoleId { get; set; }
        public int UserId { get; set; }
        public Guid UserGuid { get; set; }
        public int ApplicationId { get; set; }
        public Guid ApplicationGuid { get; set; }
        public int UserRoleId { get; set; }
        public string? UserRoleDisplayName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}