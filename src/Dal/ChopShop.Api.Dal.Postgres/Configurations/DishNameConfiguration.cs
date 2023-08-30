using ChopShop.Api.Dal.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChopShop.Api.Dal.Postgres.Configurations;

public class DishNameConfiguration: IEntityTypeConfiguration<DishName>
{
    public void Configure(EntityTypeBuilder<DishName> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        
        builder.HasOne(x => x.Dish)
            .WithMany(x => x.Names)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Language)
            .IsRequired();
        
        builder.Property(x => x.Value)
            .IsRequired();
    }
}