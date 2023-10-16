using ChopShop.Api.Dal.MenuContext.Models.Enums;

namespace ChopShop.Api.Dal.MenuContext.Models;

public class DishName
{
    public Guid Id { get; init; }
    public LanguageType Language { get; set; }
    public string Value { get; set; } = null!;
    public Dish Dish { get; } = null!;
    public Guid DishId { get; init; }
}