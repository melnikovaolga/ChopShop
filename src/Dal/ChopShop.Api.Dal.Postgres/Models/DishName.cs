using ChopShop.Api.Dal.Postgres.Models.Enums;

namespace ChopShop.Api.Dal.Postgres.Models;

public class DishName
{
    public Guid Id { get; init; }
    public LanguageType Language { get; set; }
    public string Value { get; set; } = null!;
    public Dish Dish { get; } = null!;
    public Guid DishId { get; init; }
}