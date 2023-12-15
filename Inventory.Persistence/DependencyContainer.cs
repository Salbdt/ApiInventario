using Inventory.Persistence.Interfaces;
using Inventory.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public static IServiceCollection AddAuthContextSQLServer(
            this IServiceCollection services,
            IConfiguration configuration,
            string connectionStringName
        )
        {
            services.AddSqlServer<AuthContext>(configuration.GetConnectionString(connectionStringName));
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

        public static IServiceCollection AddAuthContextSQLite(
            this IServiceCollection services,
            IConfiguration configuration,
            string connectionStringName
        )
        {
            services.AddSqlite<AuthContext>(configuration.GetConnectionString(connectionStringName));
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IInventoryMovementRepository, InventoryMovementRepository>();
            services.AddScoped<IInventoryStockRepository, InventoryStockRepository>();
            services.AddScoped<IMovementTypeRepository, MovementTypeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            
            return services;
        }
    }
}