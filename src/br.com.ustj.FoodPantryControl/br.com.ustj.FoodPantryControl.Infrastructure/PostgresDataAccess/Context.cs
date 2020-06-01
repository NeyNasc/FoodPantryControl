using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace br.com.ustj.FoodPantryControl.Infrastructure.PostgresDataAccess
{
    public class Context : DbContext
    {        
        public DbSet<Entities.Log.Log> Log { get; set; }
        public DbSet<Entities.Item.Item> Item { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Environment.GetEnvironmentVariable("FOODPANTRY_CONN") != null)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("FOODPANTRY_CONN"), npgsqlOptionsAction: options =>
                {
                    options.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), new List<string>());
                    options.MigrationsHistoryTable("_MigrationHistory", "FoodPantryControl");
                });
            }
            else
            {
                optionsBuilder.UseInMemoryDatabase("FoodPantryControl");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            
            modelBuilder.ApplyConfiguration(new Entities.Map.ItemMap());
            modelBuilder.ApplyConfiguration(new Entities.Map.LogMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
