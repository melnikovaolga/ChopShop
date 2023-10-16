using ChopShop.Api.Dal.MenuContext.Configurations;
using ChopShop.Api.Dal.MenuContext.Models;
using Microsoft.EntityFrameworkCore;

namespace ChopShop.Api.Dal.MenuContext;

public class MenuContext: DbContext
{
    public DbSet<Dish> Dish { get; } = null!;
    public DbSet<DishName> DishName { get; } = null!;

    public MenuContext(DbContextOptions<MenuContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new DishConfiguration());
        builder.ApplyConfiguration(new DishNameConfiguration());
        builder.ApplyConfiguration(new DishPriceConfiguration());
    }
}