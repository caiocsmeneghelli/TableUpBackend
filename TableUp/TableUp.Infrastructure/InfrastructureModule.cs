using TableUp.Infrastructure.Persistence.Repositories;
using TableUp.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace TableUp.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories();
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Register your repositories here
            services.AddScoped<IMenuCategoryRepository, MenuCategoryRepository>();
            return services;
        }
    }
}
