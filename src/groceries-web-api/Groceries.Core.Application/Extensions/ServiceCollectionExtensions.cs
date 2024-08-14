using FluentValidation;
using Groceries.Core.Application.Data;
using Groceries.Core.Application.Helpers;
using Groceries.Core.Application.Models.DTOs.Requests;
using Groceries.Core.Application.Validators;
using Groceries.Infrastructure.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Groceries.Core.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPostgresDbContext(this IServiceCollection services, PostgresOptions postgresOptions)
        {
            services.AddDbContext<GroceriesDbContext>(options =>
            {
                options.UseNpgsql(
                    $"Host={postgresOptions.Host};Database={postgresOptions.Database};Username={postgresOptions.Username};Password={postgresOptions.Password}");
            });
            services.AddTransient<IGroceriesDbContext, GroceriesDbContext>();

            return services;
        }

        public static IServiceCollection AddApplicationModelMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AppAutoMapperCartProfile));
            return services;
        }

        public static void AddDatabaseMigrations(this IServiceCollection services){
            var groceriesDatabaseContext = services.BuildServiceProvider().GetRequiredService<GroceriesDbContext>();
            groceriesDatabaseContext.Database.Migrate();
        }

        public static IServiceCollection AddDTOValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<UpdateCartRequestDTO>, UpdateCartDTOValidator>();
            services.AddScoped<IValidator<UpdateCartItemRequestDTO>, UpdateCartItemDTOValidator>();
            services.AddScoped<IValidator<CreateCartRequestDTO>, CreateCartDTOValidator>();
            services.AddScoped<IValidator<CreateCartItemRequestDTO>, CreateCartItemDTOValidator>();
            return services;
        }
    }
}