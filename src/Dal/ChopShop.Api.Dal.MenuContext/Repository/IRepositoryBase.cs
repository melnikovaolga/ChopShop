namespace ChopShop.Api.Dal.MenuContext.Repository;

public interface IRepositoryBase<out TEntity>
{
    IAsyncEnumerable<TEntity> GetAllAsync();
}