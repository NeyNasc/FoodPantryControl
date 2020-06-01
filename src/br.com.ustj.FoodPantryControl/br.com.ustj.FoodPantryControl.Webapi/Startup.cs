using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using br.com.ustj.FoodPantryControl.Webapi.DependencyInjection;
using br.com.ustj.FoodPantryControl.Webapi.Pipeline;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace br.com.ustj.FoodPantryControl.Webapi
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }
        public ILifetimeScope AutofacContainer { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ConfigurationModule(Configuration));
            builder.AddAutofacRegistration();
        }

        public void ConfigureServices(IServiceCollection services)
        {            
            services.Cors();
            services.Swagger();
            services.AddLocalization();
            services.AddProblemDetails();
            services.AddFilters();
            services.AddOptions();
            services.AddMvc().AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var serviceProvider = app.ApplicationServices;
            var resouces = serviceProvider.GetService<IStringLocalizer<Resources.ReturnMessages>>();

            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new ErrorHandlerMiddleware(env, resouces).Invoke
            });

            app.UseCors();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseMiddleware<LogRequestMiddleware>();
            app.AddLocalization();
            app.UseProblemDetails();
            app.Swagger();
            app.AddOptions();
            app.UseRouting();
            app.UseEndpoints(e => e.MapControllers());
        }
    }
}
