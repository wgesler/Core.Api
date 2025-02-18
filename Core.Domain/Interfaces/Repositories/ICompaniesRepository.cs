using Core.Domain.Models.Companies;

namespace Core.Domain.Interfaces.Repositories
{
    public interface ICompaniesRepository
    {
        Task<Company?> AddCompany(string displayName, int createdBy);
        Task<CompanyAttribute?> AddCompanyAttribute(int companyId, string attributeName, string value, int createdBy);
        Task<Company?> GetCompanyById(int id);
        Task<Company?> GetCompanyByGuid(Guid guid);
        Task<Company?> GetCompanyByName(string displayName);
        Task<Company?> UpdateCompany(int companyId, string displayName, int modifiedBy);
        Task<IEnumerable<Company>> GetCompaniesWhereAttributeExists(string attributeName);
        Task<bool> DeactivateCompany(int id, int modifiedBy);
        Task<CompanyApplication?> AddCompanyApplication(int companyId, int applicationId, int createdBy);
        Task<CompanyApplication?> GetCompanyApplicationById(int companyApplicationId);
        Task<IEnumerable<CompanyApplication>?> GetCompanyApplicationsByCompanyId(int companyId);
        Task<List<string?>> GetCompanyApplicationListByCompanyGuid(Guid companyGuid);
        Task<bool> DeleteCompanyApplication(int companyApplicationId);
    }
}
