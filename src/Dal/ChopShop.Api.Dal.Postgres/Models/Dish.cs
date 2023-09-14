using ChopShop.Api.Dal.Postgres.Models.Enums;

namespace ChopShop.Api.Dal.Postgres.Models;

public class Dish
{
    public Guid Id { get; init; }

    public IEnumerable<DishName> Names { get; init; } = null!;

    public IEnumerable<DishPrice> Prices { get; init; } = null!;
    
    public AvailabilityType Availability { get; set; }

}