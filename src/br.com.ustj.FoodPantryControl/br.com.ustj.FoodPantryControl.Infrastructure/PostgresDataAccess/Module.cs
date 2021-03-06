﻿using Autofac;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace br.com.ustj.FoodPantryControl.Infrastructure.PostgresDataAccess
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var connection = Environment.GetEnvironmentVariable("FOODPANTRY_CONN");

            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(t => (t.Namespace ?? string.Empty).Contains("PostgresDataAccess"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(t => (t.Namespace ?? string.Empty).Contains("PostgresDataAccess") && typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                .As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                    cfg.AddProfile(profile);

                cfg.AddExpressionMapping();
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                .CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();


            builder.RegisterType<Context>().InstancePerLifetimeScope();

            if (!string.IsNullOrEmpty(connection))
            {
                using Context context = new Context();
                
                context.Database.Migrate();
                ContextInitializer.Seed(context);
            }
        }
    }
}
