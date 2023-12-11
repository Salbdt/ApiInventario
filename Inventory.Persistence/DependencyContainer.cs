using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Persistence
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddContextSQLServer(
            this IServiceCollection services,
            IConfiguration configuration,
            string connectionString
        )
        {
            services.AddSqlServer<DataContext>(configuration.GetConnectionString(connectionString));
            return services;
        }
        public static IServiceCollection AddContextSQLite(
            this IServiceCollection services,
            IConfiguration configuration,
            string connectionString
        )
        {
            services.AddSqlite<DataContext>(configuration.GetConnectionString(connectionString));
            return services;
        }
    }
}