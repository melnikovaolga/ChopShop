using ChopShop.Api.Dal.MenuContext.Models.Enums;

namespace ChopShop.Api.Dal.MenuContext.Models;

public class DishPrice
{
    public Guid Id { get; init; }
    public CurrencyType Currency { get; set; }
    public decimal Value { get; set; }
    public Dish Dish { get; } = null!;
    public Guid DishId { get; init; }
}