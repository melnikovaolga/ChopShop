using Microsoft.EntityFrameworkCore;

namespace ChopShop.Api.Dal.MenuContext.Repository;

public abstract class RepositoryBase<TEntity>: IRepositoryBase<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet;
    protected RepositoryBase(DbSet<TEntity> dbSet) => _dbSet = dbSet;

    public IAsyncEnumerable<TEntity> GetAllAsync() => _dbSet.AsAsyncEnumerable();
}