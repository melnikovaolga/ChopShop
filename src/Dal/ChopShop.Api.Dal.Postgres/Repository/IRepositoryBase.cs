using ChopShop.Api.Dal.Postgres.Context;

namespace ChopShop.Api.Dal.Postgres.Repository;

public interface IRepositoryBase<out TEntity>
{
    IAsyncEnumerable<TEntity> GetAllAsync();
}