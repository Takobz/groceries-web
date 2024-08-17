using Groceries.Core.Domain.Repositories;
using Groceries.Infrastructure.Helpers;
using Groceries.Infrastructure.Repositories.CommandRepositories;
using Groceries.Infrastructure.Repositories.QueryRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace Groceries.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICartCommandRepository, CartCommandRepository>();
            services.AddTransient<IQueryRepository<Data.DataModels.Cart>, CartQueryRepository>();
            return services;
        }

        public static IServiceCollection AddRepositoryModelMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(InfraAutoMapperCartProfile));
            return services;
        }
    }
}