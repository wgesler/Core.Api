using Core.Domain.Models.Common;

namespace Core.Domain.Models.Users
{
    public class UserRole
    {
        public int Id { get; set; }
        public string? DisplayName { get; set; }
        public Audit Audit { get; set; }

        public UserRole(int userApplicationRoleId, string displayName, Audit audit)
        {
            Id = userApplicationRoleId;
            DisplayName = displayName;
            Audit = audit;
        }
    }
}
