using Groceries.Core.Application.Helpers;

namespace Groceries.Core.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationModelMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AppAutoMapperCartProfile));
            return services;
        }
    }
}