using ChopShop.Api.Dal.MenuContext.Models;

namespace ChopShop.Api.Dal.MenuContext.Repository;

public class DishRepository: RepositoryBase<Dish>
{
    public DishRepository(MenuContext context) : base(context.Dish) {}
}