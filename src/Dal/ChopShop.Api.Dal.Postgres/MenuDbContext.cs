using ChopShop.Api.Dal.Postgres.Configurations;
using ChopShop.Api.Dal.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace ChopShop.Api.Dal.Postgres;

public class MenuDbContext: DbContext
{
    public DbSet<Dish> Dish { get; } = null!;
    public DbSet<DishName> DishName { get; } = null!;

    public MenuDbContext(DbContextOptions<MenuDbContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new DishConfiguration());
        builder.ApplyConfiguration(new DishNameConfiguration());
        builder.ApplyConfiguration(new DishPriceConfiguration());
    }
}