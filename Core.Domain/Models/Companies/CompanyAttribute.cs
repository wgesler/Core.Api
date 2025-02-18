
using Core.Domain.Models.Common;

namespace Core.Domain.Models.Companies
{
    public class CompanyAttribute : BaseAttribute
    {
        public int CompanyInfoId { get; }
        public int CompanyId { get; }
        public string? Value { get; }
        public Audit Audit { get; }

        public CompanyAttribute(int companyInfoId, int companyId, int attributeId, string attributeName, string value,
            Audit audit) : base(attributeId, attributeName)
        {
            CompanyInfoId = companyInfoId;
            CompanyId = companyId;
            Value = value;
            Audit = audit;
        }

        public CompanyAttribute(int companyId, string attributeName, string value, Audit audit)
            : base(attributeName)
        {
            CompanyId = companyId;
            Value = value;
            Audit = audit;
        }

        public CompanyAttribute(string attributeName, string value, Audit audit)
            : base(attributeName)
        {
            Value = value;
            Audit = audit;
        }
    }
}
