using Core.Domain.Models.Common;

namespace Core.Domain.Models.Users
{
    public class UserAttribute : BaseAttribute
    {
        public int UserInfoId { get; }
        public int UserId { get; }
        public string? Value { get; }
        public Audit Audit { get; }

        public UserAttribute(int companyInfoId, int companyId, int attributeId, string attributeName, string value,
            Audit audit) : base(attributeId, attributeName)
        {
            UserInfoId = companyInfoId;
            UserId = companyId;
            Value = value;
            Audit = audit;
        }

        public UserAttribute(int companyId, string attributeName, string value, Audit audit)
            : base(attributeName)
        {
            UserId = companyId;
            Value = value;
            Audit = audit;
        }

        public UserAttribute(string attributeName, string value, Audit audit)
            : base(attributeName)
        {
            Value = value;
            Audit = audit;
        }
    }
}
