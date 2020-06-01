using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace br.com.ustj.FoodPantryControl.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class LogMap : IEntityTypeConfiguration<Log.Log>
    {
        public void Configure(EntityTypeBuilder<Log.Log> builder)
        {
            builder.ToTable("Log", "FoodPantryControl");
            builder.HasKey(d => d.Id);
        }
    }
}
