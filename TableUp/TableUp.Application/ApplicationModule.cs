using Microsoft.Extensions.DependencyInjection;
using TableUp.Application.Commands.MenuCategories.Create;

namespace TableUp.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatr();
            return services;
        }

        private static IServiceCollection AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateMenuCategoryCommand).Assembly));
            return services;
        }

    }
}
