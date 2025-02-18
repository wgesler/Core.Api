using Core.Domain.Models.Sessions;
using Core.Infrastructure.Repositories.CoreDB.Dtos;
using System.Data.SqlClient;

namespace Core.Infrastructure.Repositories.CoreDB.Sessions
{
    public partial class SessionsRepository
    {
        public async Task<Session?> AddSession(Guid applicationGuid, int userId, string sessionData, DateTime expiresUTC, int createdBy)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<SessionDto>("dbo.Sessions_Add",
                        new
                        {
                            ApplicationGUID = applicationGuid,
                            UserId = userId,
                            SessionData = sessionData,
                            ExpiresUTC = expiresUTC,
                            CreatedBy = createdBy
                        });
                return ConvertDtoToModel(ret.FirstOrDefault());
            }
        }
    }
}
