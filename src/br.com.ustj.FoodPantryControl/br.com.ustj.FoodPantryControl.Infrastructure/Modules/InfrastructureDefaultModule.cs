using Autofac;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Modules
{
    public class InfrastructureDefaultModule : Module
    {      
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .AsImplementedInterfaces()
                .AsSelf().InstancePerLifetimeScope();
        }
    }
}
