using ChopShop.Api.Dal.Postgres.Models.Enum;

namespace ChopShop.Api.Dal.Postgres.Models;

public class Dish
{
    public Guid Id { get; }
    
    public IReadOnlyCollection<DishName> Names { get; }

    public decimal Price { get; }
    
    public CurrencyType Currency { get; }

    public Dish(IReadOnlyCollection<DishName> names, decimal price, CurrencyType currency)
    {
        Names = names;
        Price = price;
        Currency = currency;
    }
}