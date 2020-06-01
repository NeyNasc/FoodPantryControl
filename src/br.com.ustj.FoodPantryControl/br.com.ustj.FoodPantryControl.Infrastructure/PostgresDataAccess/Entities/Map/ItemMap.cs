using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace br.com.ustj.FoodPantryControl.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class ItemMap : IEntityTypeConfiguration<Item.Item>
    {
        public void Configure(EntityTypeBuilder<Item.Item> builder)
        {
            builder.ToTable("Item", "FoodPantryControl");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.BarCode).IsRequired();
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.ExpirationDate);
            builder.Property(p => p.InsertDate);
        }
    }
}
