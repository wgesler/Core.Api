using Core.Domain.Models.Applications;

namespace Core.Domain.Interfaces.Repositories
{
    public interface IApplicationsRepository
    {
        Task<Application?> GetApplicationByGuid(Guid guid);
        Task<Application?> GetApplicationByDisplayName(string displayName);
        Task<bool> GetApplicationIsValidApi(Guid applicationGuid, Guid apiKey);
    }
}
