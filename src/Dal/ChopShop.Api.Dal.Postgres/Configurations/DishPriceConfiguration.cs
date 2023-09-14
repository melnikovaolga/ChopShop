using ChopShop.Api.Dal.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChopShop.Api.Dal.Postgres.Configurations;

public class DishPriceConfiguration: IEntityTypeConfiguration<DishPrice>
{
    public void Configure(EntityTypeBuilder<DishPrice> builder)
    {
        builder.ToTable("DishPrice");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Currency)
            .IsRequired();
        
        builder.Property(x => x.Value)
            .IsRequired();
        
        builder.HasOne(x => x.Dish)
            .WithMany(x => x.Prices)
            .OnDelete(DeleteBehavior.Restrict);
    }
}