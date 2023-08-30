using ChopShop.Api.Dal.Postgres.Context;
using ChopShop.Api.Dal.Postgres.Models;

namespace ChopShop.Api.Dal.Postgres.Repository;

public class DishNameRepository: RepositoryBase<DishName>
{
    public DishNameRepository(PostgresContext context) : base(context.DishName) {}
}