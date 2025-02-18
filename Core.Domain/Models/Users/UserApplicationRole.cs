using Core.Domain.Models.Common;

namespace Core.Domain.Models.Users
{
    public class UserApplicationRole
    {
        public int UserApplicationRoleId { get; }
        public Identifier UserIdentifier { get; }
        public Identifier ApplicationIdentifier { get; }
        public int UserRoleId { get; }
        public string UserRoleDisplayName { get; }
        public Audit Audit { get; }

        public UserApplicationRole(int userApplicationRoleId, Identifier userIdentifier,
            Identifier applicationIdentifier, int userRoleId, string userRoleDisplayName, Audit audit)
        {
            UserApplicationRoleId = userApplicationRoleId;
            UserIdentifier = userIdentifier;
            ApplicationIdentifier = applicationIdentifier;
            UserRoleId = userRoleId;
            UserRoleDisplayName = userRoleDisplayName;
            Audit = audit;
        }
    }
}
