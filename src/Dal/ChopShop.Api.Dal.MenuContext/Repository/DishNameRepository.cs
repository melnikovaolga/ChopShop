using ChopShop.Api.Dal.MenuContext.Models;

namespace ChopShop.Api.Dal.MenuContext.Repository;

public class DishNameRepository: RepositoryBase<DishName>
{
    public DishNameRepository(MenuContext context) : base(context.DishName) {}
}