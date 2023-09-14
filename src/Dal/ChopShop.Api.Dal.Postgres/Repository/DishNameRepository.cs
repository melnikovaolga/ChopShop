using ChopShop.Api.Dal.Postgres.Models;

namespace ChopShop.Api.Dal.Postgres.Repository;

public class DishNameRepository: RepositoryBase<DishName>
{
    public DishNameRepository(MenuDbContext context) : base(context.DishName) {}
}