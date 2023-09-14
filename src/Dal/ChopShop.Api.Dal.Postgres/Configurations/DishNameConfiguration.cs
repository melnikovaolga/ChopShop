using ChopShop.Api.Dal.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChopShop.Api.Dal.Postgres.Configurations;

public class DishNameConfiguration: IEntityTypeConfiguration<DishName>
{
    public void Configure(EntityTypeBuilder<DishName> builder)
    {
        builder.ToTable("DishName");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Language)
            .IsRequired();
        
        builder.Property(x => x.Value)
            .IsRequired()
            .HasMaxLength(60);
        
        builder.HasOne(x => x.Dish)
            .WithMany(x => x.Names);
    }
}