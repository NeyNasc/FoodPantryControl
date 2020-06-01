using Autofac;
using br.com.ustj.FoodPantryControl.Infrastructure.Modules;
using br.com.ustj.FoodPantryControl.Webapi.Modules;

namespace br.com.ustj.FoodPantryControl.Webapi.DependencyInjection
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddAutofacRegistration(this ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<FoodPantryControl.Infrastructure.PostgresDataAccess.Module>();
            builder.RegisterModule<InfrastructureDefaultModule>();
            builder.RegisterModule<WebapiModule>();

            return builder;
        }
    }
}
