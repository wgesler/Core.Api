using Dapper;
using FourT.Shared.Utilities.MicroServices.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace Core.Api.Health
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        private readonly string _dbCommString;

        public DatabaseHealthCheck(IOptions<AppSettings> appSettings)
        {
            _dbCommString = appSettings.Value.DBConnections.Find(o => o.DBName.ToLower() == "coredb")!.ConnectionString;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                using var db = new SqlConnection(_dbCommString);
                var response = await db.ExecuteAsync("SELECT 1");

                return HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy(exception: ex);
            }
        }
    }
}
