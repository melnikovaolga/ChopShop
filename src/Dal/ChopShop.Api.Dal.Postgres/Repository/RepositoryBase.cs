using Microsoft.EntityFrameworkCore;

namespace ChopShop.Api.Dal.Postgres.Repository;

public abstract class RepositoryBase<TEntity>: IRepositoryBase<TEntity> where TEntity : class
{
    protected readonly DbSet<TEntity> Table;
    protected RepositoryBase(DbSet<TEntity> table) => Table = table;

    public IAsyncEnumerable<TEntity> GetAllAsync() => Table.AsAsyncEnumerable();
}