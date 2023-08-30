using ChopShop.Api.Dal.Postgres.Models.Enum;

namespace ChopShop.Api.Dal.Postgres.Models;

public class DishName
{
    public Guid Id { get; }
    public LanguageType Language { get; }
    public string Value { get; }

    public Dish Dish { get; } = null!;
    public Guid DishId { get; }
    
    public DishName(Guid dishId, LanguageType language, string value)
    {
        Language = language;
        Value = value;
        DishId = dishId;
    }
}