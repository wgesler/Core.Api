using System.Data.SqlClient;
using FourT.Shared.Utilities.Extensions;

namespace Core.Infrastructure.Repositories.CoreDB.Sessions
{
    public partial class SessionsRepository
    {
        public async Task<bool> DeleteSession(Guid sessionGuid)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcExecuteAsync("dbo.Sessions_DeleteByGuid",
                    new
                    {
                        SessionGuid = sessionGuid
                    });

                return ret > 0;
            }
        }
    }
}
