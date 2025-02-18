
using Core.Domain.Models.Common;

namespace Core.Domain.Models.Companies
{
    public class Company
    {
        public Identifier Identifier { get; }
        public string DisplayName { get; }
        public bool IsActive { get; }
        public Audit Audit { get; }
        public IEnumerable<CompanyAttribute> CompanyInfo { get; private set; }
        public IEnumerable<CompanyApplication> CompanyApplications { get; private set; }

        public Company(string displayName, IEnumerable<CompanyAttribute> companyInfo, Audit audit)
        {
            if (string.IsNullOrEmpty(displayName))
                throw new ArgumentException("Argument is required.", nameof(displayName));

            Identifier = new Identifier();
            DisplayName = displayName;
            CompanyInfo = companyInfo;
            Audit = audit;

            CompanyApplications = new List<CompanyApplication>().AsReadOnly();
        }

        public Company(Identifier identifier, string displayName, Audit audit)
        {
            if (string.IsNullOrEmpty(displayName))
                throw new ArgumentException("Argument is required.", nameof(displayName));

            Identifier = identifier;
            DisplayName = displayName;
            Audit = audit;

            CompanyInfo = new List<CompanyAttribute>().AsReadOnly();
            CompanyApplications = new List<CompanyApplication>().AsReadOnly();
        }

        public Company(Identifier identifier, string displayName, bool isActive, Audit audit)
        {
            if (string.IsNullOrEmpty(displayName))
                throw new ArgumentException("Argument is required.", nameof(displayName));

            Identifier = identifier;
            DisplayName = displayName;
            IsActive = isActive;
            Audit = audit;

            CompanyInfo = new List<CompanyAttribute>().AsReadOnly();
            CompanyApplications = new List<CompanyApplication>().AsReadOnly();
        }

        public void SetCompanyInfo(IEnumerable<CompanyAttribute> companyInfo)
        {
            CompanyInfo = companyInfo;
        }

        public void SetCompanyApplications(IEnumerable<CompanyApplication> companyApplications)
        {
            CompanyApplications = companyApplications;
        }
    }
}
