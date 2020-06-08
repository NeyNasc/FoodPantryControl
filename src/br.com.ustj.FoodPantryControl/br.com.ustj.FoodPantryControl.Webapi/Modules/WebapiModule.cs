using Autofac;
using br.com.ustj.FoodPantryControl.Application.Boudaries;
using br.com.ustj.FoodPantryControl.Application.Boudaries.Item;
using br.com.ustj.FoodPantryControl.Webapi.UseCases.Delete;
using br.com.ustj.FoodPantryControl.Webapi.UseCases.Gedoc;
using System.Linq;

namespace br.com.ustj.FoodPantryControl.Webapi.Modules
{
    public class WebapiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .Where(w => w.Namespace.Contains("UseCases"))
                .AsImplementedInterfaces()
                .AsSelf().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .Where(type => type.Namespace.Contains("Notification"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<ItemPresenter>().As<IOutputPort<ItemOutput>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ItemDeletePresenter>().As<IOutputPort<ItemOutput>>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
