using Core.Domain.Models.Common;

namespace Core.Domain.Models.Companies
{
    public class CompanyApplication
    {
        public int CompanyApplicationId { get; }
        public Identifier CompanyIdentifier { get; }
        public Identifier ApplicationIdentifier { get; }
        public Audit Audit { get; }

        public CompanyApplication(int companyApplicationId, Identifier companyIdentifier, Identifier applicationIdentifier, Audit audit)
        {
            CompanyApplicationId = companyApplicationId;
            CompanyIdentifier = companyIdentifier;
            ApplicationIdentifier = applicationIdentifier;
            Audit = audit;
        }
    }
}
