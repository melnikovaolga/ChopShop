using ChopShop.Api.Dal.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace ChopShop.Api.Dal.Postgres.Context;

public class PostgresContext: DbContext
{
    public DbSet<Dish> Dish { get; } = null!;
    public DbSet<DishName> DishName { get; } = null!;
}