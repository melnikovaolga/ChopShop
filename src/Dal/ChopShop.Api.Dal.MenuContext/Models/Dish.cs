using ChopShop.Api.Dal.MenuContext.Models.Enums;

namespace ChopShop.Api.Dal.MenuContext.Models;

public class Dish
{
    public Guid Id { get; init; }

    public IEnumerable<DishName> Names { get; init; } = null!;

    public IEnumerable<DishPrice> Prices { get; init; } = null!;
    
    public AvailabilityType Availability { get; set; }

}