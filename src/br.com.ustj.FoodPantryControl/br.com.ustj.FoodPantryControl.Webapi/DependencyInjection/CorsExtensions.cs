using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace br.com.ustj.FoodPantryControl.Webapi.DependencyInjection
{
    public static class CorsExtensions
    {
        public static IServiceCollection Cors(this IServiceCollection services)
        {
            var allowedHosts = Environment.GetEnvironmentVariable("ALLOWED_HOSTS").Split("|").ToList();

            allowedHosts.Add("http://localhost:19006");

            services.AddCors(options => options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins(allowedHosts.ToArray());
                policy.AllowAnyMethod();
                policy.AllowAnyHeader();
                policy.AllowCredentials();
            }));

            return services;
        }
    }
}
