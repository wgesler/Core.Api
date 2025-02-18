using Core.Domain.Models.Sessions;

namespace Core.Domain.Interfaces.Repositories
{
    public interface ISessionsRepository
    {
        Task<Session?> AddSession(Guid applicationGuid, int userId, string sessionData, DateTime expiresUtc, int createdBy);
        Task<Session?> GetSessionById(int sessionId);
        Task<Session?> GetSessionByGuid(Guid guid);
        Task<Session?> UpdateSession(int sessionId, string sessionData, int modifiedBy);
        Task<bool> ExpireSession(Guid sessionGuid);
        Task<bool> DeleteSession(Guid sessionGuid);
    }
}
