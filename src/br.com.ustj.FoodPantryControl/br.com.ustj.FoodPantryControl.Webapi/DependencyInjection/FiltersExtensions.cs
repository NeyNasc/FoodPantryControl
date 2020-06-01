using br.com.ustj.FoodPantryControl.Webapi.Filters;
using br.com.ustj.FoodPantryControl.Webapi.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace br.com.ustj.FoodPantryControl.Webapi.DependencyInjection
{
    public static class FiltersExtensions
    {
        public static IServiceCollection AddFilters(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(DomainExceptionFilter));
                options.Filters.Add(typeof(ValidateModelAttribute));
                options.Conventions.Add(new NotFoundResultApiConvention());
                options.Conventions.Add(new ProblemDetailsResultApiConvention());
            })
            .AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                {
                    return factory.Create(typeof(Resources.SharedResources));
                };
            });

            return services;
        }
    }
}
