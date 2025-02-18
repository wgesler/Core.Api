using System.Data.SqlClient;
using Core.Domain.Models.Sessions;

namespace Core.Infrastructure.Repositories.CoreDB.Sessions
{
    public partial class SessionsRepository
    {
        public async Task<Session?> UpdateSession(int sessionId, string sessionData, int modifiedBy)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<int>("dbo.Sessions_UpdateSessionDataById",
                    new
                    {
                        SessionId = sessionId,
                        SessionData = sessionData,
                        ModifiedBy = modifiedBy
                    });

                return await GetSessionById(ret.FirstOrDefault());
            }
        }

        public async Task<bool> ExpireSession(Guid sessionGuid)
        {
            var expirationDate = DateTime.UtcNow;
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<int>("dbo.Sessions_UpdateExpirationDate",
                    new
                    {
                        SessionGuid = sessionGuid,
                        ExpirationDate = expirationDate
                    });

                return ret.Any();
            }
        }
    }
}
