using Core.Domain.Models.Sessions;
using Core.Infrastructure.Repositories.CoreDB.Dtos;
using System.Data.SqlClient;

namespace Core.Infrastructure.Repositories.CoreDB.Sessions
{
    public partial class SessionsRepository
    {
        public async Task<Session?> GetSessionById(int sessionId)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<SessionDto>("dbo.Sessions_GetById", new { Id = sessionId });

                return ConvertDtoToModel(ret.FirstOrDefault());
            }
        }
        public async Task<Session?> GetSessionByGuid(Guid guid)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<SessionDto>("dbo.Sessions_GetByGUID", new { GUID = guid });

                return ConvertDtoToModel(ret.FirstOrDefault());
            }
        }

    }
}
