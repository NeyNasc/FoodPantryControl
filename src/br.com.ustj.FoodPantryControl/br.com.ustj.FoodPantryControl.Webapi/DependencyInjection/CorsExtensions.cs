using Microsoft.Extensions.DependencyInjection;
using System;

namespace br.com.ustj.FoodPantryControl.Webapi.DependencyInjection
{
    public static class CorsExtensions
    {
        public static IServiceCollection Cors(this IServiceCollection services)
        {
            var allowedHosts = Environment.GetEnvironmentVariable("ALLOWED_HOSTS").Split("|");

            services.AddCors(options => options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins(allowedHosts);
                policy.AllowAnyMethod();
                policy.AllowAnyHeader();
                policy.AllowCredentials();
            }));

            return services;
        }
    }
}
