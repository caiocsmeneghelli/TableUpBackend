using Microsoft.Extensions.DependencyInjection;
using TableUp.Application.Commands.MenuCategories.Create;
using FluentValidation;

namespace TableUp.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatr()
                .AddValidators();
            return services;
        }

        private static IServiceCollection AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateMenuCategoryCommand).Assembly));
            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateMenuCategoryCommandValidator>();
            return services;
        }
    }
}
