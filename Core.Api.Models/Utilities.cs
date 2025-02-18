
namespace Core.Api.Helpers
{
    public class DbConnection
    {
        string DBName { get; set; } = string.Empty;
        string ConnectionString { get; set; } = string.Empty;
    }
	public class ServiceConnection
	{
        string ServiceName { get; set; } = string.Empty;
		string ServiceURL { get; set; } = string.Empty;
	}


    public class AppSettings
    {
        string Environment { get; set; } = string.Empty;
        string AllowedHostNames { get; set; } = string.Empty;
		List<DbConnection> DBConnections { get; set; }
        List<ServiceConnection> ServiceConnections { get; set; }
    }


    public static class Utilities
    {
        public static bool NullablesNotNull<T>(this T obj)
        {            
            return typeof(T).GetProperties().All(propertyInfo => Nullable.GetUnderlyingType(propertyInfo.PropertyType) == null && propertyInfo.GetValue(obj) != null);
        }
    }
}
