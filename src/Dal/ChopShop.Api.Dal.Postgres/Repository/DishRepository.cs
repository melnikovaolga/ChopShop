using ChopShop.Api.Dal.Postgres.Models;

namespace ChopShop.Api.Dal.Postgres.Repository;

public class DishRepository: RepositoryBase<Dish>
{
    public DishRepository(MenuDbContext context) : base(context.Dish) {}
}