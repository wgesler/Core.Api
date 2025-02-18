
namespace Core.Infrastructure.Repositories.CoreDB.Dtos
{
    public class UserRoleDto
    {
        public int UserRoleId { get; set; }
        public string? DisplayName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
