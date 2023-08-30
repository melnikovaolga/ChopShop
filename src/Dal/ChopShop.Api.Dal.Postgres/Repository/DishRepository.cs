using ChopShop.Api.Dal.Postgres.Context;
using ChopShop.Api.Dal.Postgres.Models;

namespace ChopShop.Api.Dal.Postgres.Repository;

public class DishRepository: RepositoryBase<Dish>
{
    public DishRepository(PostgresContext context) : base(context.Dish) {}
}