using Groceries.Core.Domain.Repositories;
using Groceries.Infrastructure.Helpers;
using Groceries.Infrastructure.Repositories.CommandRepositories;
using Groceries.Infrastructure.Repositories.DbContexts;
using Groceries.Infrastructure.Repositories.QueryRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Groceries.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPostgresDbContext(this IServiceCollection services, PostgresOptions postgresOptions)
        {
            services.AddDbContext<IGroceriesDbContext, GroceriesDbContext>(options =>
            {
                options.UseNpgsql(
                    $"Host={postgresOptions.Host};Database={postgresOptions.Database};Username={postgresOptions.Username};Password={postgresOptions.Password};Port={postgresOptions.Port}");
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICartCommandRepository, CartCommandRepository>();
            services.AddTransient<IQueryRepository<Data.DataModels.Cart>, CartQueryRepository>();
            return services;
        }

        public static IServiceCollection AddRepositoryModelMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperCartProfile));
            return services;
        }
    }
}