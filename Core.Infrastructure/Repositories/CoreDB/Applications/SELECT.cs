using Core.Domain.Models.Applications;
using Core.Infrastructure.Repositories.CoreDB.Dtos;
using System.Data.SqlClient;

namespace Core.Infrastructure.Repositories.CoreDB.Applications
{
	public partial class ApplicationsRepository
    {
        public async Task<Application?> GetApplicationByGuid(Guid guid)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<ApplicationDto>("dbo.Applications_GetByGuid", new { Guid = guid });

                return ConvertDtoToModel(ret.FirstOrDefault());
            }
        }

        public async Task<Application?> GetApplicationByDisplayName(string displayName)
        {
            using (var db = new SqlConnection(_dbConnectionString))
            {
                var ret = await db.DapperProcQueryAsync<ApplicationDto>("dbo.Applications_GetByDisplayName", new { DisplayName = displayName });

                return ConvertDtoToModel(ret.FirstOrDefault());
            }
        }

        public async Task<bool> GetApplicationIsValidApi(Guid applicationGuid, Guid apiKey)
        {
            try
            {
                using (var db = new SqlConnection(_dbConnectionString))
                {
                    var ret = await db.DapperProcQueryAsync<int>("dbo.Applications_GetValidApi", new { ApplicationGuid = applicationGuid, ApiKey = apiKey });

                    return ret.FirstOrDefault() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
